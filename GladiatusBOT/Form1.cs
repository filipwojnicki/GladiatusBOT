using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using HtmlAgilityPack;
using System.IO;
using System.Web;

namespace GladiatusBOT
{

    public partial class Form1 : Form
    {
        int serverCount = 36;
        static int server = 33;

        int expeditionCount = 12;
        int expeditionDone = 0;

        int dungeonCount = 12;
        int dungeonDone = 0;

        string sh;

        string globalLink = "https://s" + server.ToString() + "-pl.gladiatus.gameforge.com/game/";

        bool expeditionStarted = false;

        List<string> wordsPL = new List<string>(new string[] {
            "odbierz bonus", "ok", "nie", "Załóż przedmiot", "Do areny",
            "Pracuj", "Praca","Dom aukcyjny", "Rynek", "Kuźnia", "Magus Hermeticus",
            "Anuluj", "Przejdź do kostiumów",
        });
        
        public Form1()
        {
            InitializeComponent();
            if (Properties.Settings.Default.server != "" && Regex.IsMatch(Properties.Settings.Default.server, @"^\d+$"))
            {
                webBrowser1.Navigate("https://s" + Properties.Settings.Default.server + "-pl.gladiatus.gameforge.com/");
                comboBox1.Text = Properties.Settings.Default.server;
            }
            else
                webBrowser1.Navigate("https://gladiatus.pl/");

            if (Properties.Settings.Default.monster != "" && Regex.IsMatch(Properties.Settings.Default.monster, @"^\d+$"))
                comboBox2.Text = Properties.Settings.Default.monster;
            
            if (Properties.Settings.Default.location != "" && Regex.IsMatch(Properties.Settings.Default.location, @"^\d+$"))
                comboBox4.Text = Properties.Settings.Default.location;

            completeLoginForm();

            richTextBox1.Text = "Lokalizacja: \r\n 0 - Mroczne lasy \r\n 6 - Obóz bandytów \r\n" +
                " \r\n Potwory: \r\n 1 - pierwszy od lewej \r\n 4 - ostatni w danej lokacji \r\n" +
                " \r\n Lokalizacje i potwory można zmieniać podczas działania programu. \r\n" +
                " \r\n Jeżeli brakuje jakieś lokalizacji lub potwora proszę spróbować samemu dodać odpowiadający mu wg przykladu. Do pól oprócz serwera można wpisywać dane ręcznie. \r\n" +
                " \r\n Aby korzystać z lochów, wejdz na interesujący Cię, wybierz typ, i pokonaj pierwszego potwora, bot bd chodził na ten loch który bd po przyciskiem Do Lochów. \r\n";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://s" + comboBox1.Text + "-pl.gladiatus.gameforge.com/");
            server = Convert.ToInt32(comboBox1.Text);
            globalLink = "https://s" + server.ToString() + "-pl.gladiatus.gameforge.com/game/";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            webBrowser1.ScriptErrorsSuppressed = true;

            for (int i = 1; i <= 4; i++) comboBox2.Items.Add(i);
            for (int i = 0; i <= 6; i++) comboBox4.Items.Add(i);

            server = Convert.ToInt32(comboBox1.Text);
            globalLink = "https://s" + server.ToString() + "-pl.gladiatus.gameforge.com/game/";

            //Convert list to uppercase
            wordsPL = wordsPL.ConvertAll(d => d.ToUpper());

        }

        int getExpeditionCount() 
        {
            //wait for browser
            DateTime start = DateTime.Now;
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
                if (webBrowser1.IsDisposed || DateTime.Now.Subtract(start).TotalSeconds > 8.0) break;
            }

            int countExpedition = 12;
            int countCache =  Convert.ToInt32(webBrowser1.Document.GetElementById("expeditionpoints_value_point").InnerText);

            Debug.Write(countCache);

            if (countCache >= 0 && countCache <= 24)
                countExpedition = countCache;

            Debug.WriteLine("Punkty wypraw: "+countExpedition.ToString());

            return countExpedition;
        }

        int getDungeonCount()
        {
            //wait for browser
            DateTime start = DateTime.Now;
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
                if (webBrowser1.IsDisposed || DateTime.Now.Subtract(start).TotalSeconds > 8.0) break;
            }

            int countDungeon = 12;
            int countCache = Convert.ToInt32(webBrowser1.Document.GetElementById("dungeonpoints_value_point").InnerText);

            if (countCache >= 0 || countCache <= 24)
                countDungeon = countCache;

            //Debug.WriteLine("Punkty lochów: " + countDungeon);

            return countDungeon;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            if (isLogin()) sh = getSh();

            //sif (isLogin()) expeditionCount = getExpeditionCount();

            HtmlElementCollection elc = webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement el in elc)
            {
                // check if list contains HTML element value
                if (wordsPL.FirstOrDefault(stringToCheck => stringToCheck.Contains(el.GetAttribute("value").ToUpper())) != null)
                    el.InvokeMember("Click");

            }
        }

        bool isLogin() 
        {
            if (webBrowser1.Document != null)
                if (webBrowser1.Document.GetElementById("loginForm") != null)
                    return false;

            server = Convert.ToInt32(comboBox1.Text);
            globalLink = "https://s" + server.ToString() + "-pl.gladiatus.gameforge.com/game/";
            sh = getSh();

            Debug.WriteLine("SH: "+sh);

            return true; 
        }

        void completeLoginForm()
        {
            if (Properties.Settings.Default.login != "")
                loginBox.Text = Properties.Settings.Default.login;

            if (Properties.Settings.Default.password != "")
                passBox.Text = Properties.Settings.Default.password;

            if (comboBox1.Items.Count < serverCount)
                for (int i = 1; i <= serverCount; i++) comboBox1.Items.Add(i);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.login = loginBox.Text;
                Properties.Settings.Default.password = passBox.Text;
                Properties.Settings.Default.server = comboBox1.Text;

                Properties.Settings.Default.Save();
            }

            if (logIn())
            {
                loginPanel.Hide();
                loadPlayerData();
                logoutButton.Visible = true;
                //sh = getSh();
            }    
        }

        bool logIn() 
        {
            if (isLogin() == false)
            {
                loginPanel.Show();
                /*
                 * webBrowser1.Navigate("https://s" + comboBox1.Text + "-pl.gladiatus.gameforge.com/");
                
                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                 */

                server = Convert.ToInt32(comboBox1.Text);
                globalLink = "https://s" + server.ToString() + "-pl.gladiatus.gameforge.com/game/";
                 

                webBrowser1.Document.GetElementById("login_username").InnerText = loginBox.Text;
                webBrowser1.Document.GetElementById("login_password").InnerText = passBox.Text;

                HtmlElementCollection elc = this.webBrowser1.Document.GetElementsByTagName("input");
                foreach (HtmlElement el in elc)
                {
                    if (el.GetAttribute("value").Equals("Login"))
                    {
                        el.InvokeMember("Click");
                        loginPanel.Hide();
                        logoutButton.Visible = true;
                        return true;
                    }
                }
                
             
            }

            loginPanel.Hide();
            logoutButton.Visible = true;
            return false;
        }

        void loadPlayerData() 
        {
            HtmlElementCollection elc = this.webBrowser1.Document.GetElementsByTagName("a");
            foreach (HtmlElement el in elc)
            {
                if (el.GetAttribute("title").Equals("Podgląd"))
                {
                    el.InvokeMember("Click");
                   
                }
            }

            HtmlElementCollection e = webBrowser1.Document.GetElementsByTagName("div");
            foreach (HtmlElement a in e)
            {
                if (a.GetAttribute("class").Equals("playername ellipsis"))
                {
                    nickTxt.Text = a.InnerText.ToString();
                }
            }
      
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            string logoutLink = globalLink;

            HtmlElementCollection a = webBrowser1.Document.GetElementsByTagName("a");
            foreach (HtmlElement link in a) 
            {
                if (link.InnerText == "Wyloguj")
                    logoutLink = link.GetAttribute("href");
            }
            webBrowser1.Navigate(logoutLink);
            logoutButton.Visible = false;
            loginPanel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            expeditionDone = 0;

            if (!expeditionStarted)
            {
                if (isLogin())
                {
                    webBrowser1.Navigate(globalLink);

                    //wait for browser
                    DateTime start = DateTime.Now;
                    while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                    {
                        Application.DoEvents();
                        if (webBrowser1.IsDisposed || DateTime.Now.Subtract(start).TotalSeconds > 8.0) break;
                    }

                    expeditionCount = getExpeditionCount();
                    if (canGoOnExpedition()) goExpedition();
                    expeditionTimer.Interval = getExpeditionTime();
                    expeditionTimer.Enabled = true;

                    Debug.Write("Expedition Count: "+expeditionCount);

                    dungeonCount = getDungeonCount();
                    if (checkBox3.Checked == true)
                    {
                        dungeonTimer.Interval = getDungeonTime() + 20000;
                        dungeonTimer.Enabled = true;
                    }

                    button2.Text = "Stop";
                }
                else
                    MessageBox.Show("Nie jesteś zalogowany, lub problem ze sprawdzeniem logowania.");
            }
            else
            {
                expeditionTimer.Enabled = false;
                dungeonTimer.Enabled = false;
                button2.Text = "Wyprawa";
            }

            expeditionStarted = !expeditionStarted;


        }

        private void dungeonTimer_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("dungeon");

            System.Threading.Thread.Sleep(1000);

            if(dungeonDone <= dungeonCount)
            {
                if (!canGoOnDungeon())
                {
                    dungeonTimer.Interval = getDungeonTime();
                }
                else
                {
                    goDungeon();
                    dungeonDone++;
                    System.Threading.Thread.Sleep(1000);
                    dungeonTimer.Interval = getDungeonTime();
                }
                Debug.WriteLine("Razy: " + dungeonDone);
            }

        }

        private void expeditionTimer_Tick(object sender, EventArgs e)
        {

            System.Threading.Thread.Sleep(1000);

            if (expeditionDone <= expeditionCount)
            {
                // Debug.WriteLineLine(Convert.ToInt32(getExpeditionTime()));


                if (!canGoOnExpedition())
                {
                    expeditionTimer.Interval = getExpeditionTime();
                }
                else
                {
                    goExpedition();
                    expeditionDone++;
                    System.Threading.Thread.Sleep(1000);
                    expeditionTimer.Interval = getExpeditionTime();
                }
                //Debug.WriteLine("Work:" + getExpeditionTime() + " ,Razy: " + expeditionDone);

            }

            if(expeditionDone >= expeditionCount)
            {
                
                Debug.Write("Wyprawy zakończone \r\n Wykonały się: " + expeditionDone.ToString());

                expeditionTimer.Enabled = false;
                dungeonTimer.Enabled = false;
                expeditionDone = 0;
                dungeonDone = 0;

                expeditionStarted = false;
                button2.Text = "Wyprawa";

                if (checkBox2.Checked) workTimer.Enabled = true;
            }

        }

        int getExpeditionTime()
        {
            string time = "";

            if (!canGoOnExpedition())
            {
                time = webBrowser1.Document.GetElementById("cooldown_bar_text_expedition").InnerText;
                Debug.WriteLine(TimeSpan.Parse(time).TotalMilliseconds);
                if (Convert.ToInt32(TimeSpan.Parse(time).TotalMilliseconds) >= 20 * 1000)
                    return Convert.ToInt32(TimeSpan.Parse(time).TotalMilliseconds) + 3000;
                else
                    return 19000;
            }
            return 10000;
        }

        int getDungeonTime()
        {
            string time = "";

            if (!canGoOnDungeon())
            {
                time = webBrowser1.Document.GetElementById("cooldown_bar_text_dungeon").InnerText;
                Debug.WriteLine(TimeSpan.Parse(time).TotalMilliseconds);
                if (Convert.ToInt32(TimeSpan.Parse(time).TotalMilliseconds) >= 20 * 1000)
                    return Convert.ToInt32(TimeSpan.Parse(time).TotalMilliseconds) + 3000;
                else
                    return 19000;
            }
            return 10000;
        }

        void goWork() 
        {
            if (isLogin())
            {
                webBrowser1.Navigate(globalLink + "index.php?mod=work&sh=" + sh);

                //wait for browser
                DateTime start = DateTime.Now;
                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                    if (webBrowser1.IsDisposed || DateTime.Now.Subtract(start).TotalSeconds > 8.0) break;
                }

                object[] args = { " setWorkTime(2, 8, 8, 1); " };
                webBrowser1.Document.InvokeScript("eval", args);

                HtmlElementCollection inp = webBrowser1.Document.GetElementsByTagName("input");
                foreach (HtmlElement i in inp)
                {
                    if (i.GetAttribute("id") == "doWork" || i.GetAttribute("value") == "Jazda!")
                        i.InvokeMember("Click");
                }

                workTimer.Enabled = false;
            }      
        }

        void goExpedition() 
        {
            //sendJS("document.getElementsByClassName('cooldown_bar_link')[0].getAttribute('href')");

            if (isLogin())
            {
                webBrowser1.Navigate(globalLink + "index.php?mod=location&loc=" + comboBox4.Text + "&sh=" + sh);

                object[] args = { " attack(null,'" + comboBox4.Text + "', " + comboBox2.Text + ", 1, '') " };

                System.Threading.Thread.Sleep(1000);

                //wait for browser
                DateTime start = DateTime.Now;
                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                    if (webBrowser1.IsDisposed || DateTime.Now.Subtract(start).TotalSeconds > 8.0) break;
                }

                try
                {
                    if (canGoOnExpedition()) webBrowser1.Document.InvokeScript("eval", args);

                    Debug.WriteLine("razy: " + expeditionDone);
                }
                catch (Exception err)
                {
                    Debug.WriteLine(err);
                }
            } 
        }

        

        //private string sendJS(string JScript)
        //{
        //    object[] args = { JScript };
        //    return webBrowser1.Document.InvokeScript("eval", args).ToString();
        //}

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.location = comboBox4.Text;
            Properties.Settings.Default.Save();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.monster = comboBox2.Text;
            Properties.Settings.Default.Save();
        }

        bool canGoOnExpedition()
        {
            string expeditionTxt = "Na wyprawę";

            HtmlElementCollection a = webBrowser1.Document.GetElementsByTagName("div");
            foreach (HtmlElement l in a)
                if (l.GetAttribute("id") == "cooldown_bar_text_expedition")
                    if (l.InnerText == expeditionTxt) return true;

            return false;
        }

        bool canGoOnDungeon()
        {
            string expeditionTxt = "Do lochów";

            HtmlElementCollection a = webBrowser1.Document.GetElementsByTagName("div");
            foreach (HtmlElement l in a)
                if (l.GetAttribute("id") == "cooldown_bar_text_dungeon")
                    if (l.InnerText == expeditionTxt) return true;

            return false;
        }

        string getSh()
        {
            HtmlElementCollection a = webBrowser1.Document.GetElementsByTagName("a");
            foreach (HtmlElement l in a)
            {
                if (l.InnerText == "Wyloguj" || l.InnerText == "wyloguj")
                {
                    Uri buri = new Uri(l.GetAttribute("href"));

                    var queryvalues = buri.Query.Replace("?", "").Split('&').Select(q => q.Split('=')).ToDictionary(k => k[0], v => v[1]);
                    return queryvalues["sh"];
                }
            }

            return "";
        }

        private void testbttn_Click(object sender, EventArgs e)
        {
            goWork();
        }



        void goDungeon()
        {
            var doc = new HtmlAgilityPack.HtmlDocument();

            //wait for browser
            DateTime start = DateTime.Now;
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
                if (webBrowser1.IsDisposed || DateTime.Now.Subtract(start).TotalSeconds > 8.0) break;
            }

            if (isLogin())
            {
                doc.Load(new StringReader(this.webBrowser1.Document.Body.OuterHtml));

                String dungeonLink = HtmlEntity.DeEntitize(doc.DocumentNode.SelectNodes("//div[@id='cooldown_bar_dungeon']/a").First().Attributes["href"].Value);
                webBrowser1.Navigate(globalLink + dungeonLink);

                //wait for browser
                DateTime start2 = DateTime.Now;
                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                    if (webBrowser1.IsDisposed || DateTime.Now.Subtract(start2).TotalSeconds > 8.0) break;
                }

                doc.Load(new StringReader(this.webBrowser1.Document.Body.OuterHtml));

                List<dungeonScript> scripts = new List<dungeonScript>();
                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div/div[@onclick]"))
                {
                    if (!node.GetAttributeValue("onclick", "").Equals("mmoShowOptions(1)"))
                    {
                        Debug.WriteLine(node.GetAttributeValue("onclick", ""));

                        scripts.Add(new dungeonScript { JSScript=node.GetAttributeValue("onclick", "").ToString() });
                    }
                        
                }

                if (!scripts.Any()) return;

                string randomScript = scripts.PickRandom().JSScript;

                if (randomScript.Contains("return false;"))
                    randomScript = randomScript.Remove(randomScript.IndexOf("return false;"), "return false;".Length);

                object[] args = { randomScript };

                try
                {
                    if (canGoOnDungeon()) webBrowser1.Document.InvokeScript("eval", args);
                }
                catch (Exception err)
                {
                    Debug.WriteLine(err);
                }




                //foreach (var script in scripts)
                //{
                //    Debug.WriteLine("test"+script.JSScript);
                //}


            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (isLogin())
            {
                var doc = new HtmlAgilityPack.HtmlDocument();

                //wait for browser
                DateTime start = DateTime.Now;
                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                    if (webBrowser1.IsDisposed || DateTime.Now.Subtract(start).TotalSeconds > 8.0) break;
                }

                doc.Load(new StringReader(this.webBrowser1.Document.Body.OuterHtml));
                int playerLevel = Convert.ToInt32(HtmlEntity.DeEntitize(doc.DocumentNode.SelectNodes("//div[@id='header_values_level']").First().InnerText));

                if(playerLevel < 10 && checkBox3.Checked)
                {
                    MessageBox.Show("Masz za niski poziom ,aby korzystać z lochów.");
                    checkBox3.Checked = false;
                }

            }
            else
            {
                if (checkBox3.Checked)
                {
                    MessageBox.Show("Musisz być zalogowany ,aby wybrać tą opcję.");
                    checkBox3.Checked = false;
                }
            }      
        }

        private void workTimer_Tick(object sender, EventArgs e)
        {
            goWork();
        }
    }

    class dungeonScript
    {
        public string JSScript;
    }

    public static class EnumerableExtension
    {
        public static T PickRandom<T>(this IEnumerable<T> source)
        {
            return source.PickRandom(1).Single();
        }

        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(x => Guid.NewGuid());
        }
    }
}
