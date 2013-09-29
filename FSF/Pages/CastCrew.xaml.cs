using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FSF.Pages
{
    public partial class CastCrew : PhoneApplicationPage
    {
        public CastCrew()
        {
            InitializeComponent();
            Loaded += CastCrew_Loaded;
        }
        private void CastCrew_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = CastCrewInfo.People[0];

            int i = -1;
            foreach (Person p in CastCrewInfo.People)
            {
                i++;
                Image im = new Image
                {
                    Source = new BitmapImage(new Uri(p.MugShot, UriKind.Relative)),
                    Tag = i,
                    Margin = new Thickness(5, 0, 5, 0)
                };
                im.Tap += im_Tap;
                Stack_People.Children.Add(im);
            }
        }
        private void im_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            scroll_info.ScrollToVerticalOffset(0);
            this.DataContext = CastCrewInfo.People[(int)(sender as Image).Tag];
        }
        private void twit_click(object sender, RoutedEventArgs e)
        {
            if ((sender as HyperlinkButton).Tag.ToString() == "none")
            {
                MessageBox.Show("This is the one fella who doesn't have twitter from the whole gang.", "No account to open.", MessageBoxButton.OK);
            }
            else
            {
                new WebBrowserTask { Uri = new Uri("http://twitter.com/" + (sender as HyperlinkButton).Tag.ToString(), UriKind.Absolute) }.Show();
            }
        }
    }

    public static class CastCrewInfo
    {
        private static List<Person> people = new List<Person>();
        public static List<Person> People
        {
            get
            {
                if (people.Count == 0)
                {
                    people.Add(new Person("Alec Owen", "Alec was discovered by 5SF in 2011 when they were in need of an Osama bin Laden, which is upsetting at best. He performs standup comedy around L.A., where he was born for some reason. He acts in things and writes stuff and does a third more humorous and ridiculous thing. He can be followed on Twitter at @alecowen, where he has a special relationship with @SlimJim.", "alecowen"));
                    people.Add(new Person("Ben Gigli", "Raised by gypsies in the midst of an historical re-enactment of medieval Krakow, Ben Gigli is 40ft tall and assembled primarily from bamboo and a variety of water-soluble glues. He is a USC graduate with a BA in International Relations and Film as well as a Masters in Communications Management (the Internet). He has worked and consulted for a number web media companies in Los Angeles. He also has co-founded a number of totally unsuccessful web ventures and is currently working on yet another (welcome). He enjoys writing, acting, and long walks on the beach.His ultimate goal in life is to own and successfully ride a solid gold jet-ski.", "bengigli"));
                    people.Add(new Person("Brian Firenzi", "Brian is going to tell you the same thing he’s going to tell everyone at his 10-year high school reunion: After investing wisely in the stock market, Brian developed that one app that does that thing, pretty technical, don’t need to get into it, anyway it did pretty well. Then he did a bunch of uncredited voice work for commercials and Saturday morning cartoons, met all his idols in Hollywood, and after being buff and healthy for so long, has recently taken a $1 million payday to write a book about putting on weight for a year. What’s that, you say? Facebook? That must be some other Brian Firenzi (Walks over to the refreshments table, takes an extra cookie).", "brian_and_maria"));
                    people.Add(new Person("Daniel K. Hollister", "Daniel spent way too many hours building this website, and it still doesn’t work very well. He has nothing more to say about himself at this time.", "notdaniel"));
                    people.Add(new Person("Erik Sandoval", "Erik Sandoval is a writer and director.", "none"));
                    people.Add(new Person("Joey Bertran", "FADE IN. Joey’s story mirrors The Godfather. So don’t even think you can mess with anyone of his friends or family members, because if you do… that’ll be the last thing you ever do. All Joey has to do is make a quick phone call to Uncle Tony and he’ll have any of you two-timing, rat-bastards, taken care of. Capice? Joey does what he does when he does it. When he’s done with what he’s doin’ he relaxes, but most of the time he’s doin’ stuff. If you gotta problem, he’ll fix it. If you gotta problem with him, he’ll tell you to “Go f*** yourself.” Get the picture? Joey actively pursues all aspects of filmmaking and will continue to do so. End of story. FADE OUT.", "joey2meals"));
                    people.Add(new Person("Jon Salmon", "Jon Salmon prefers to hang out behind the camera. Not because of any kind of innate visual talent or fascination with the psychological atmosphere of cinema, but because he’s seriously just Medusa-ugly. He directed the unofficial MGMT video on youtube with 38 million views and typically hides his bizarre joke of a face in the edit bay at 5sf. He’s also kind of a pretty boy and a decent cinematographer.", "jonsalmon7"));
                    people.Add(new Person("Jon Worley", "Jon Worley is a writer. He enjoys tackboard, V-necks, black organic coffee, and loose women. Mess with him and he’ll cut you. For more info, go fuck yourself.", "jaawworley"));
                    people.Add(new Person("Kelsey Gunn", "Kelsey was born in 1924 to a Vaudeville ingenue and a clown-wrangling father. After discovering the fountain of youth, she attended Washington State University where she graduated with a BA in Theatre and Music. She then proceeded to move to Los Angeles where she has been in several talking movies and fantastical television shows including Castle (ABC), How to be a Gentleman (CBS), Chelsea Lately (E!), and a recurring role on Community (NBC), as well as many independent films and webseries. She is honored to make seconds of film every week and contribute to the lack of attention spans worldwide. You’re welcome.", "kelseygunn"));
                    people.Add(new Person("Maria del Carmen", "On a stormy day in London, Maria was just a baby in a carriage, resting precariously at the top of a hill. Lightning struck a tree, sending a flaming branch crashing into the handlebars, and subsequently Maria rolled downhill, reaching incredible speeds. Through sheer luck, the carriage narrowly missed 12 cars as it wobbled through a busy intersection, slammed into a curb, and sent Maria flying into American internet comedy. To this day, she won’t do jokes about thunder or lightning.", "missmariacarmen"));
                    people.Add(new Person("Michael E. Peter", "Michael E. Peter doesn’t ask permission to be a filmmaker. He spends his days working in the broom closet of the Hollywood industry and his nights plotting revolution with the next generation of storytellers. A late-bloomer in the world of 5-second cinema, Michael cut his teeth on a 5,383 second film, Chronicles of a Love Unfound. For more information on that project and Michael’s stubbornly idealistic view on cinema, go to straydogproductions.net.", "michaelepeter"));
                    people.Add(new Person("Michael Rousselet", "Michael Rousselet is blonde, he wears black-framed glasses and is a better screenwriter than a grammarist. He has written some stuff including most notably José (Finalist: 2008 Sasha Screenwriting Grant) and Thís (Finalist: 2009 5sf Bio). In 2003 Michael saw a movie called The Room, he became manically obsessed with it and told way too many people. He’s very sorry for the damage he has done to cinema and is trying hard to rectify it.", "mrrousselet"));
                    people.Add(new Person("Mike James", "Mike James escaped the cornfields of Indiana for a life of glamour and adventure in Hollywood. He got his big break working at “America’s Funniest Videos”, but his meteoric rise in television was abruptly ended by the cancellation of “The Bonnie Hunt Show”. Unemployment, debt, and one hell of a drinking habit lead him to a bunch of derelict filmmakers known as 5-Second Films. 5SF found Mike starving, naked, and stunningly handsome. They took him in and nursed him back to health. He is now a writer/director plotting to take over the world.", "heymikejames"));
                    people.Add(new Person("Olivia Taylor Dudley", "Olivia was born at the bottom of the ocean, raised by a family of magical sea ponies and, after spending the first 1,100 years of her life in a world of water, she built a space shuttle (with help from a herd of sea slugs) and blasted into space! Never to look back. After landing on Pluto she decided to join the Prestigious Plutonian Drama Club and soon became the biggest star on the planet! Having conquered this planet she decided to grow wings and fly to the larger planet known as Earth and joined a group of gypsies whose trade of 5-second moving pictures soon became the talk of the town. She is a vegetarian.", "oliviadudley"));
                    people.Add(new Person("Paul Prado", "Paul Prado wandered onto the set of Rescue 911 in the episode “Peeved Preschooler.” True story. Despite being too young to comprehend such harsh realities, he was encouraged to wander onto another set, which turned out to be an episode of Unsolved Mysteries. At age 5, he was disappointed that neither experiences led him to a chance encounter with William Shatner. LA proved too much for the man so he moved to Hemet, California. Hemet also proved too much for the man so he moved back to LA and attended USC, broke some world records, travelled in the wrong circles, and ended up here. He counts all these to be loss for the excellency of the knowledge of comedy.", "iwantyourtweets"));
                    people.Add(new Person("Tim Ciancio", "By day he checks focus on celebrities for the E! channel, and by night cleanses his palette shooting, editing, and making shitty FX for this here website. His dog and cat moved into the 5SF house in 2010 and they allow him to stay there while he pays student loans and collects their hair. He yearns to someday make films with substance, depth, and meaning that demands viewing on a screen larger than any Best Buy has in stock.", "timizims"));
                    people.Add(new Person("Tomm Jacobsen", "Tomm likes to shoot things. Women, children, puppies. Give him a camera and he will shoot just about anything.", "papertomm"));
                }

                return people;
            }
        }
    }

    public class Person
    {
        public Person(string name, string bio, string twitter = "none")
        {
            this.Name = name;
            this.Bio = bio;
            this.Twitter = twitter;
        }

        public string Name { get; set; }
        public string Bio { get; set; }
        public string Twitter { get; set; }
        public string MugShot
        {
            get
            {
                return "/Images/CastCrew/" + this.Name.Replace(" ", string.Empty).Replace(".", string.Empty).ToLower() + ".jpg";
            }
        }
    }
}