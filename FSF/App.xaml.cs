using Classes;
using FSF.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Telerik.Windows.Controls;

namespace FSF
{
    public partial class App : Application
    {
        #region VARS
        public static PhoneApplicationFrame RootFrame { get; private set; }
        private bool phoneApplicationInitialized = false;
        public RadDiagnostics RadDiagnostic = new RadDiagnostics
        {
            EmailTo = "CrisRowlands@1800PocketPC.com",
            IncludeScreenshot = false,
            ApplicationName = "5SF",
            EmailSubject = "5SF Error report."
        };
        #endregion

        #region LIFECYCLE
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            ApplicationUsageHelper.Init("4.0");

            if (VideoManager.Films.Videos.Count == 0)
            {
                VideoManager.Films.Videos.Add(new Video { ID = "5bkh90-tXiE", VideoName = "Great Comeback", Description = "​​​​He said it. He couldn't take it back. Goobity-Dop. Those fateful syllables hung in the thick summer air like a chandelier of daggers held by flimsy threads, ready to break loose and wreak havoc on their friendship. Indeed, the first shots in a long war were fired in that moment, soon crescendoing with a Ford F-150 crashing through a downstairs bathroom with 400 pounds of nitroglycerin in the pickup. The Great Goobity-Dop War of 2013 ended with 72 people dead, and 2 injured so badly they asked to be killed later anyway." });
                VideoManager.Films.Videos.Add(new Video { ID = "osZa0XqOvPE", VideoName = "Afflecktion", Description = "​​People tried to make hacky jokes on Twitter about how Matt Damon should play the moon, but Matt Damon, those people, and everyone involved with running the servers at Twitter were flung far into space in the resulting cataclysm that detonated entire tectonic plates in seconds. In fact, the last tweet ever made was \"They should have asked Bale back to play Earth, hey why is the ground shaking? Da fu-\"" });
                VideoManager.Films.Videos.Add(new Video { ID = "16MTViJPM9E", VideoName = "Dirty Boyfriend", Description = "​​He's so dirty that his girlfriend went back in time, enrolled at Bath University, nabbed a cheerleading uniform, got caught on her way back to the time machine by the Dean of Academics, was ordered to go back to class at once, and proceeded to spend four years of higher education all over again, just so she could send her boyfriend (whom she totally had the option of not meeting, ever again, in the new timeline she created for herself, yet chose to stay the course for some bizarre reason) a message about just kinda cleaning up in general and not having chips on his naked chest all the time. This is how time travel was meant to be used.​" });
                VideoManager.Films.Videos.Add(new Video { ID = "t5vk8ZknAlM", VideoName = "19th Century Gentlemanscaping", Description = "​​​Way back in the entirety of the 19th Century, men's vital arteries were located entirely in their balls (then referred to as \"The Danger Zone\"). Sure, it made the rest of their bodies tough enough to handle the depression, but it made pubestripping a real danger. So using the power of concentration, they willed all their vitals to different parts of their bodies, and by 1986 the evolution was complete. Kenny Loggins even commemorated the death of the Danger Zone with a song, and all was right with the world.​" });
                VideoManager.Films.Videos.Add(new Video { ID = "TovkwNmx0ik", VideoName = "Working On The Chain Gang", Description = "​​They may not get any work done, but unlike a surly teenage boy, they'll never pretend they're working when really they're just masturbating furiously. You have to respect the honesty here." });
                VideoManager.Films.Videos.Add(new Video { ID = "hvh7j8bzqCo", VideoName = "They Can Dance If They Want To", Description = "​​​The indian in the cupboard had enough. He and his brethren were going to be respected, they were going to get referred to by their actual tribe name as opposed to a country on the opposite side of the world, and they were going to get some water because they were really thirsty, and after the water bowl incident with Cassidy last week, the kitchen was more or less deemed the Graveyard of Souls." });
                VideoManager.Films.Videos.Add(new Video { ID = "UdzdQ_YlKh8", VideoName = "Foreplay", Description = "​​​These guys are looking to caddyshack up by putting from the rough, but they're playing miniature golf if you catch my drift. If you don't catch my drift, they're golf puns. I was saying they are horny and resorting to bizarre methods to get women, but they have small dicks. I did it through the power of puns. It's okay, you don't understand what those are, it's sweet, really." });
                VideoManager.Films.Videos.Add(new Video { ID = "2tDwcrAYP1g", VideoName = "Hold Me Closer Tiny Batman", Description = "​​​These​Sometimes one little word is all it takes to change the meaning of a sentence entirely. For example, Tomm didn't find Batman WHILE walking down the street. He found Batman walking down the street WHILE he was receiving sexual favors from a book with a hole cut in it, meant for storing a flask of whiskey. See? Completely different meanings." });
            }

            if (VideoManager.Sketches.Videos.Count == 0)
            {
                VideoManager.Sketches.Videos.Add(new Video { ID = "N2mLtCAvvt8", VideoName = "RoboCop’s Kickstarter To Save Detroit", Description = "​​​When The City of Detroit is filed for Chapter 9 bankruptcy, RoboCop knew that he had to come to the city's aid. And so he's coming to YOU, the fans, to see if we can all come together and SAVE DETROIT! Watch the video for more info on our fabulous prizes." });
                VideoManager.Sketches.Videos.Add(new Video { ID = "xcvZiZRhy_k", VideoName = "How To Write A Successful Hollywood Screenplay", Description = "​​​​Want to learn all the $ecrets to making it big in Hollywood? It's all in the $creenplay! Well in \"Screenwriting 1001: How To Write A Successful Screenplay for Modern Hollywood\" you'll learn all those $alacious detail$!!!" });
                VideoManager.Sketches.Videos.Add(new Video { ID = "1ZLuy3fZzH8", VideoName = "PLAY - BY - PLAY", Description = "​​​​This radio broadcast is brought to you by Brenson / Boondecker Bail Bonds." });
                VideoManager.Sketches.Videos.Add(new Video { ID = "EOPUO9j7TJ8", VideoName = "Old Man Reports The News: “Episode thr3e", Description = "​​​​Clem Werther cracks the case of the Illuminati! Did you hate \"Old Man Reports the News\"? Then we have the best news of all to report to you: This is our last episode of Clem Werther and his antics!." });
            }
        }
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            if (!e.IsApplicationInstancePreserved)
            {
                ApplicationUsageHelper.OnApplicationActivated();
            }
        }
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
        }
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }
        #endregion

        #region ERRORS
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }
        #endregion

        #region INIT
        public App()
        {
            UnhandledException += Application_UnhandledException;
            InitializeComponent();
            InitializePhoneApplication();
            InitializeLanguage();
            RadDiagnostic.Init();
        }
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized) return;
            RootFrame = new RadPhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;
            phoneApplicationInitialized = true;
        }
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            if (RootVisual != RootFrame) RootVisual = RootFrame;
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }
        #endregion

        // Initialize the app's font and flow direction as defined in its localized resource strings.
        //
        // To ensure that the font of your application is aligned with its supported languages and that the
        // FlowDirection for each of those languages follows its traditional direction, ResourceLanguage
        // and ResourceFlowDirection should be initialized in each resx file to match these values with that
        // file's culture. For example:
        //
        // AppResources.es-ES.resx
        //    ResourceLanguage's value should be "es-ES"
        //    ResourceFlowDirection's value should be "LeftToRight"
        //
        // AppResources.ar-SA.resx
        //     ResourceLanguage's value should be "ar-SA"
        //     ResourceFlowDirection's value should be "RightToLeft"
        //
        // For more info on localizing Windows Phone apps see http://go.microsoft.com/fwlink/?LinkId=262072.
        //
        private void InitializeLanguage()
        {
            try
            {
                // Set the font to match the display language defined by the
                // ResourceLanguage resource string for each supported language.
                //
                // Fall back to the font of the neutral language if the Display
                // language of the phone is not supported.
                //
                // If a compiler error is hit then ResourceLanguage is missing from
                // the resource file.
                RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);

                // Set the FlowDirection of all elements under the root frame based
                // on the ResourceFlowDirection resource string for each
                // supported language.
                //
                // If a compiler error is hit then ResourceFlowDirection is missing from
                // the resource file.
                FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
                RootFrame.FlowDirection = flow;
            }
            catch
            {
                // If an exception is caught here it is most likely due to either
                // ResourceLangauge not being correctly set to a supported language
                // code or ResourceFlowDirection is set to a value other than LeftToRight
                // or RightToLeft.

                if (Debugger.IsAttached)
                {
                    Debugger.Break();
                }

                throw;
            }
        }
    }
}