using System;
using osuElements;
using osuElements.Helpers;
using osuElements.Storyboards;
//this makes our life easier, no need to be typing these in anymore!
using static osuElements.Storyboards.Easing;
using static osuElements.Storyboards.EventLayer;
using static osuElements.Storyboards.Looptypes;
using static osuElements.Storyboards.Origin;

namespace SampleCode
{
    public class FullSglFile
    {
        //this is a conversion of Charles445's storyboard on his map "DM vs. POCKET - uNDeRWoRLD MoNaRCHy"
        //https://osu.ppy.sh/s/412938
        //I left out all of the redundant code, osuElements/c# will take care of that
        //I'll mark most changes with the original with *()
        //I wont be repeating the comments, check them out in the original if you don't understand why something is done a certain way

        private static Random rand;//fields because they need to be accessed from other methods
        private static Storyboard storyboard;

        private static void Main(string[] args) {
            //we are creating a new storyboard, not starting from an existing one
            storyboard = new Storyboard();
            storyboard.FullPath =
                "412938 DM vs POCKET - uNDeRWoRLD MoNaRCHy\\DM vs. POCKET - uNDeRWoRLD MoNaRCHy (Charles445).osb";
            //rand works a bit different in c#
            rand = new Random();



            //var coverslip = new Sprite("sb/udt_cover.png", Background, Centre);
            //coverslip.fade(0, 0);
            //coverslip.scale(0, 0.67);
            //coverslip.move(0, 320, 240);
            //coverslip.fade(7445, 1);
            //coverslip.fade(433393, 435427, 1, 0);

            var coverslip = new SpriteEvent("sb\\udt_cover.png"); //slashes need to be either "\\" or @"\" because this is an escape character https://msdn.microsoft.com/en-us/library/h21280bw.aspx

            storyboard.AddSpriteEvent(coverslip); // you can do this before or after adding transformations, doesn't matter
            coverslip.Fade(0, 0);
            coverslip.Scale(0, 2 / 3f); //use the "f" to use decimal numbers *(0.67 is 2/3)
            //*(moving to 320,240 is redundant because that is the default location)
            coverslip.Fade(7445, 1);
            coverslip.Fade(433393, 435427, None, 1, 0); //notice we should type Easing.None if we didnt have that include at the top of the file


            //begin credits
            //*(We don't need to specify Background and Centre because these are the default values)
            var compby = new SpriteEvent(@"sb\compby.png"); //background and centre are the default values, it's redundant to type them!
            var tfox = new SpriteEvent(@"sb\tfox.png");
            var sbmap = new SpriteEvent(@"sb\sbmap.png");
            var cfourfive = new SpriteEvent(@"sb\cfourfive.png");
            var arrangedby = new SpriteEvent(@"sb\arrangedby.png");
            var dokuro = new SpriteEvent(@"sb\dokuro.png");
            var dokuro2 = new SpriteEvent(@"sb\dokuro.png");
            storyboard.AddSpriteEvent(compby);
            storyboard.AddSpriteEvent(tfox);
            storyboard.AddSpriteEvent(sbmap);
            storyboard.AddSpriteEvent(cfourfive);
            storyboard.AddSpriteEvent(arrangedby);
            storyboard.AddSpriteEvent(dokuro);
            storyboard.AddSpriteEvent(dokuro2);

            //use floats for everything except colours
            const float cred_topy = 115; //use constants if you don't change the value at runtime
            const float cred_descscale = 2f / 3;
            const float cred_namescale = 2f / 3;
            const float cred_boty = 245;

            compby.Scale(12869, cred_descscale);
            compby.MoveY(12869, cred_topy);//*(we only want to change the Y value -> use MoveY)
            compby.Fade(12869, 13547, None, 0, 1); // We need to specify the Easing when we are working with "starttime,endtime,easing,values"

            tfox.Scale(13547, cred_namescale);
            tfox.MoveY(13547, cred_boty);
            tfox.Fade(13547, 14225, None, 0f, 1);

            compby.Fade(14903, 15411, None, 1, 0);
            tfox.Fade(14903, 15411, None, 1, 0);

            sbmap.Scale(15581, cred_descscale);
            sbmap.MoveY(15581, cred_topy);
            sbmap.Fade(15581, 16259, None, 0, 1);

            cfourfive.Fade(16259, 16937, 0, 1);
            cfourfive.MoveY(16259, cred_boty);
            cfourfive.Scale(16259, cred_namescale);

            sbmap.Fade(17615, 18123, None, 1, 0);
            cfourfive.Fade(17615, 18123, None, 1, 0);

            arrangedby.Fade(18293, 19819, None, 0, 1);
            arrangedby.Fade(18293, cred_descscale);
            arrangedby.MoveY(18293, cred_topy);

            dokuro.Rotate(21871, 0);
            dokuro.Scale(21871, cred_namescale);
            dokuro.Fade(21871, 24925, None, 0, 1);
            dokuro.MoveY(21871, cred_boty);

            arrangedby.Fade(24925, 26015, None, 1, 0);
            //using a function that is defined below
            dokurovibrate(27305, 30010, dokuro, 22, cred_boty);
            dokuro.Fade(30010, 0);

            //PSYCHE
            dokuro.Fade(302885, 1);
            dokurovibrate(302885, 305088, dokuro, 22, cred_boty);
            dokuro.Fade(305088, 0);

            dokuro2.Rotate(305088, 0);
            dokuro2.Scale(305088, cred_namescale);
            dokuro2.Fade(305088, 1);
            dokuro2.MoveY(305088, cred_boty);

            arrangedby.Fade(305088, 305258, None, 0, 1);
            arrangedby.Fade(305258, 305427, None, 1, 0);
            dokuro2.Fade(305258, 305427, None, 1, 0);

            cfourfive.Fade(305597, 306275, None, 0, 1);
            sbmap.Fade(305597, 306275, None, 0, 1);
            cfourfive.Fade(306614, 307292, None, 1, 0);
            sbmap.Fade(307461, 307800, None, 1, 0);

            tfox.Fade(307970, 308309, None, 0, 1);
            compby.Fade(307970, 308309, None, 0, 1);
            tfox.Fade(308648, 309156, None, 1, 0);
            compby.Fade(309326, 310343, None, 1, 0);
            //END CREDITS


            // BEGIN PURPLE BAR
            var purplebar = new SpriteEvent("sb\\purple_bar.png", Background, BottomCentre);
            storyboard.AddSpriteEvent(purplebar);
            purplebar.MoveY(30004, 480);
            purplebar.Fade(30004, 1);

            const float purplebar_xscale = 2;
            const float purplebar_halfway = 0.55f;
            const float purplebar_scrunch = 0.05f;
            const int purplebar_delay = 1200;
            //ScaleVec is called ScaleVector and uses Position objects (the same goes for Move)
            purplebar.ScaleVector(30004, new Position(purplebar_xscale, purplebar_scrunch));

            purplebar_loop(30004, 6, purplebar, purplebar_delay, purplebar_xscale, purplebar_halfway, purplebar_scrunch);
            purplebar_loop(98139, 9, purplebar, purplebar_delay, purplebar_xscale, purplebar_halfway, purplebar_scrunch);
            purplebar_loop(162885, 12, purplebar, purplebar_delay / 1.25, purplebar_xscale, purplebar_halfway, purplebar_scrunch);
            purplebar_loop(218478, 24, purplebar, purplebar_delay / 1.75, purplebar_xscale, purplebar_halfway, purplebar_scrunch);
            purplebar_loop(313732, 11, purplebar, purplebar_delay / 1.25, purplebar_xscale, purplebar_halfway, purplebar_scrunch);
            purplebar_loop(408309, 8, purplebar, purplebar_delay / 1.5, purplebar_xscale, purplebar_halfway, purplebar_scrunch);


            purplebar.Fade(34749, 0);
            purplebar.Fade(35427, 1);
            purplebar.Fade(45597, 0);
            purplebar.Fade(46275, 1);
            purplebar.Fade(51698, 53732, None, 1, 0);
            purplebar.Fade(98139, 98239, None, 0, 1);
            purplebar.Fade(139834, 140851, None, 1, 0);
            purplebar.Fade(162885, 162985, None, 0, 1);
            purplebar.Fade(205766, 206190, None, 1, 0);
            purplebar.Fade(218478, 218578, None, 0, 1);
            purplebar.Fade(245935, 246867, None, 1, 0);
            purplebar.Fade(313732, 313832, None, 0, 1);
            purplebar.Fade(355427, 356444, None, 1, 0);
            purplebar.Fade(408309, 408359, None, 0, 1);
            purplebar.Fade(430766, 433393, None, 1, 0);
            // END PURPLE BAR

            // BEGIN HEART HIGHRES
            var bigheart = new SpriteEvent("sb/heart_hr.png");
            storyboard.AddSpriteEvent(bigheart);
            const float bigheartfademax = 0.2f;
            const float bigheartminscale = 0.51f;
            const float bigheartmaxscale = 0.75f;

            bigheart.Scale(218477, bigheartfademax);
            bigheart.Color(218477, Colour.Red);// new Colour(255, 0, 0));

            var loopbh1 = bigheart.CreateLoop(218477, 14);
            loopbh1.Fade(1, 1017, None, 0, bigheartfademax);
            loopbh1.Fade(1017, 2034, Out, bigheartfademax, 0);

            var loopbh2 = bigheart.CreateLoop(218477, 84);
            loopbh2.Scale(1, 170, None, bigheartmaxscale, bigheartminscale);
            loopbh2.Scale(170, 339, None, bigheartminscale, bigheartminscale);

            dokurovibrate(218477, 246952, bigheart, 20, 240);
            bigheart.Fade(246952, 0);
            //END HEART HIGHRES

            //BEGIN FLAMESPECKS
            flamespeck_spawn(30004, 51698, 65, 60, false);
            flamespeck_spawn(98139, 139834, 35, 60, false);
            flamespeck_spawn(162885, 206275, 50, 60, false);
            flamespeck_spawn(218478, 246867, 50, 60, true);
            flamespeck_spawn(313732, 355427, 65, 60, false);
            flamespeck_spawn(408309, 433393, 130, 30, false);
            //END FLAMESPECKS

            //BEGIN LETTERS
            titledrop(30004, 51698, 40, 110, 2, 2, 0);
            titledrop(408309, 430004, 40, 70, 2, 3, 1);
            //END LETTERS

            //BEGIN LETTERS TO PELLETS
            var lpspawn = 51698;
            const float p_bxs = 0.1f;
            var p_bys = 0.7f;
            var p_ytp = 90;
            var p_ybt = 170;
            var pi = (float)Math.PI;

            //Vertical Top Row
            newpellet(80, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(105, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(130, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(143, 82, p_bxs, 0.4f, lpspawn, -1);        // Middle N
            newpellet(155, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(180, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(205, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(230, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(280, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(305, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(330, p_ytp, p_bxs, p_bys, lpspawn, -0.7f);     //Left W
            newpellet(345, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(360, p_ytp, p_bxs, p_bys, lpspawn, 0.7f);  //Right W
            newpellet(385, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(410, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(435, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(460, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(485, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(535, p_ytp, p_bxs, p_bys, lpspawn, 0);
            newpellet(565, p_ytp, p_bxs, p_bys, lpspawn, 0);

            //Vertical Bottom Row
            newpellet(115, p_ybt, p_bxs, p_bys, lpspawn, 0);
            newpellet(121, 159, p_bxs, 0.28f, lpspawn, -1);  //Left M
            newpellet(136, 159, p_bxs, 0.28f, lpspawn, 1);//Right M
            newpellet(144, p_ybt, p_bxs, p_bys, lpspawn, 0);
            newpellet(170, p_ybt, p_bxs, p_bys, lpspawn, 0);
            newpellet(195, p_ybt, p_bxs, p_bys, lpspawn, 0);
            newpellet(220, p_ybt, p_bxs, p_bys, lpspawn, 0);
            newpellet(245, p_ybt, p_bxs, p_bys, lpspawn, 0);
            newpellet(270, p_ybt, p_bxs, p_bys, lpspawn, 0);
            newpellet(295, p_ybt, p_bxs, p_bys, lpspawn, 0);
            newpellet(320, p_ybt, p_bxs, p_bys, lpspawn, 0);
            newpellet(345, p_ybt, p_bxs, p_bys, lpspawn, 0);
            newpellet(370, p_ybt, p_bxs, p_bys, lpspawn, 0);
            newpellet(420, p_ybt, p_bxs, p_bys, lpspawn, 0);
            newpellet(445, p_ybt, p_bxs, p_bys, lpspawn, 0);
            newpellet(472, 159, p_bxs, 0.28f, lpspawn, -1);  //Left Y
            newpellet(480, 180, p_bxs, 0.4f, lpspawn, 0);        //Mid Y
            newpellet(486, 159, p_bxs, 0.28f, lpspawn, 1);   //Right Y

            //Horizontal
            p_bys = 0.4f;

            //Horizontal Top Top Row
            p_ytp = 70;
            newpellet(190, p_ytp, p_bxs, p_bys, lpspawn, -pi / 2);
            newpellet(240, 93, p_bxs, p_bys, lpspawn, pi / 2); //Middle E
            newpellet(240, p_ytp, p_bxs, p_bys, lpspawn, -pi / 2);
            newpellet(290, p_ytp, p_bxs, p_bys, lpspawn, pi / 2);
            newpellet(290, 93, p_bxs, p_bys, lpspawn, -pi / 2); //Middle R
            newpellet(395, p_ytp, p_bxs, p_bys, lpspawn, pi / 2);
            newpellet(445, p_ytp, p_bxs, p_bys, lpspawn, -pi / 2);
            newpellet(445, 93, p_bxs, p_bys, lpspawn, pi / 2); //Middle R
            newpellet(550, p_ytp, p_bxs, p_bys, lpspawn, -pi / 2);

            //Horizontal Top Bottom Row
            p_ytp = 117;

            newpellet(90, p_ytp, p_bxs, p_bys, lpspawn, -pi / 2);
            newpellet(190, p_ytp, p_bxs, p_bys, lpspawn, pi / 2);
            newpellet(240, p_ytp, p_bxs, p_bys, lpspawn, -pi / 2);
            newpellet(395, p_ytp, p_bxs, p_bys, lpspawn, pi / 2);
            newpellet(500, p_ytp, p_bxs, p_bys, lpspawn, -pi / 2);
            newpellet(550, p_ytp, p_bxs, p_bys, lpspawn, pi / 2);

            //Horizontal Bottom Top Row
            p_ybt = 150;

            newpellet(183, p_ybt, p_bxs, p_bys, lpspawn, pi / 2);
            newpellet(233, 162, p_bxs, 0.4f, lpspawn, -1);       // Middle N
            newpellet(283, p_ybt, p_bxs, p_bys, lpspawn, pi / 2);
            newpellet(283, 173, p_bxs, p_bys, lpspawn, pi / 2); //Middle A
            newpellet(333, p_ybt, p_bxs, p_bys, lpspawn, pi / 2);
            newpellet(333, 173, p_bxs, p_bys, lpspawn, pi / 2); //Middle R
            newpellet(383, p_ybt, p_bxs, p_bys, lpspawn, pi / 2);
            newpellet(433, 173, p_bxs, p_bys, lpspawn, pi / 2); //Middle H

            //Horizontal Bottom Bottom Row
            p_ybt = 192;
            newpellet(183, p_ybt, p_bxs, p_bys, lpspawn, pi / 2);
            newpellet(383, p_ybt, p_bxs, p_bys, lpspawn, pi / 2);
            //END LETTERS TO PELLETS

            //BEGIN LETTERSLICE
            var slice_x = 75;
            var slice_y = 118;

            new_slice("ct_u_l", slice_x, slice_y, 1);
            new_slice("ct_u_r", slice_x, slice_y, 0);
            slice_x += 50;
            new_slice("ct_n_l", slice_x, slice_y, 1);
            new_slice("ct_n_r", slice_x, slice_y, 0);
            slice_x += 50;
            new_slice("ct_d_l", slice_x, slice_y, 1);
            new_slice("ct_d_r", slice_x, slice_y, 0);
            slice_x += 50;
            new_slice("ct_e_l", slice_x, slice_y, 1);
            new_slice("ct_e_r", slice_x, slice_y, 0);
            slice_x += 50;
            new_slice("ct_r_l", slice_x, slice_y, 1);
            new_slice("ct_r_r", slice_x, slice_y, 0);
            slice_x += 50;
            new_slice("ct_w_l", slice_x, slice_y, 1);
            new_slice("ct_w_r", slice_x, slice_y, 0);
            slice_x += 53; //typo?
            new_slice("ct_o_l", slice_x, slice_y, 1);
            new_slice("ct_o_r", slice_x, slice_y, 0);
            slice_x += 50;
            new_slice("ct_r_l", slice_x, slice_y, 1);
            new_slice("ct_r_r", slice_x, slice_y, 0);
            slice_x += 50;
            new_slice("ct_l_l", slice_x, slice_y, 1);
            new_slice("ct_l_r", slice_x, slice_y, 0);
            slice_x += 50;
            new_slice("ct_d_l", slice_x, slice_y, 1);
            new_slice("ct_d_r", slice_x, slice_y, 0);
            //END LETTERSLICE


            #region Spoilers
            //BEGIN TORHEART
            var torheart = new SpriteEvent("sb/torheart.png");
            storyboard.AddSpriteEvent(torheart);
            //Fade in start at 292037
            //Fade in end at 294410
            torheart.Fade(292037, 294410, 0, 1);
            torheart.MoveY(292037, 176);
            torheart.Scale(292037, 0.2f);
            torheart.Scale(294410, 0.25f);
            torheart.Scale(295766, 0.36f);
            torheart.Scale(296444, 0.46f);
            torheart.Scale(297037, 0.4f);

            torheart.Fade(297122, 0);

            torheartspam(297461, 310, 176, 1, 10, 50, 195, 245, 0.1, 1);
            torheartspam(297461, 310, 176, 1, 60, 90, 195, 245, 0.1, 1);
            torheartspam(297461, 310, 176, 1, 100, 140, 195, 245, 0.1, 1);
            torheartspam(297461, 310, 176, 1, 10, 50, 195, 245, 0.1, 0);
            torheartspam(297461, 310, 176, 1, 60, 90, 195, 245, 0.1, 0);
            torheartspam(297461, 310, 176, 1, 100, 140, 195, 245, 0.1, 0);

            torheartshake(torheart, 292037, 294410, 2, 2, 33.333, 22);
            torheartshake(torheart, 294410, 295766, 4, 4, 33.333, 21);
            torheartshake(torheart, 295766, 296105, 6, 6, 33.333, 11);
            torheart.MoveY(296106, 176);
            torheartshake(torheart, 296444, 296783, 9, 9, 33.333, 11);
            torheart.MoveY(296784, 176);
            torheartshake(torheart, 296953, 297122, 9, 9, 33.333, 4);
            //END TORHEART

            //BEGIN HEART
            var heart = new SpriteEvent("sb/heart.png");
            heart.Fade(30004, 1);
            heart.Move(30004, new Position(320, 330));
            heart.Color(30004, Colour.Red);

            //a lot more after this... takes some time to convert though
            #endregion




            //tell the storyboard it should be written to Storyboard.FullPath
            storyboard.WriteFile();
        }


        private static void dokurovibrate(int starttime, int endtime, SpriteEvent dokuro, int amount, float start_y) {
            const int start_x = 320;
            const int x_threshold = 4;
            const int y_threshold = 4;
            const int r_decacc = 5000;
            const int r_threshold = 125;
            const float delay = 100f / 3;

            var loopcount = (int)((endtime - starttime) / (delay * amount)) + 1; //casting to int is the same as Math.Floor()

            //loops are different than SGL, the function CreateLoop returns a LoopEvent instance
            //then you use transformations on that object
            var loop = dokuro.CreateLoop(starttime, loopcount);

            for (var i = 0; i < amount; i++) {
                var time = (int)Math.Round(i * delay);
                //creating a random position using rand.Next() for both x and y
                var pos = new Position(start_x + rand.Next(-x_threshold, x_threshold),
                    start_y + rand.Next(-y_threshold, y_threshold));
                //cast to int because the starttime cannot be a float
                loop.Move(time, pos);

                loop.Rotate(time, randdiv(-r_threshold, r_threshold, r_decacc));
            }
            //there's no endloop
        }

        private static void purplebar_loop(int start, int repeats, SpriteEvent purplebar, double purplebar_delay, float purplebar_xscale, float purplebar_halfway, float purplebar_scrunch) {
            var loop = purplebar.CreateLoop(start, repeats);

            var first = new Position(purplebar_xscale, purplebar_scrunch);
            var second = new Position(purplebar_xscale, purplebar_halfway);
            var third = new Position(purplebar_xscale, purplebar_halfway * 2);

            loop.ScaleVector(0, (int)purplebar_delay, Out, first, second);
            loop.ScaleVector((int)purplebar_delay, (int)(purplebar_delay * 2), In, second, third);
            loop.ScaleVector((int)(purplebar_delay * 2), (int)(purplebar_delay * 3), Out, third, second);
            loop.ScaleVector((int)(purplebar_delay * 3), (int)(purplebar_delay * 4), In, second, first);
        }

        private static void flamespeck_spawn(int time, int endtime, int amount, int delay, bool spazversion) {
            for (var i = 0; i < amount; i++) {
                flamespeck_new(time + i * delay, endtime, endtime, spazversion);
                //@@ Note how none of the variables sent to this function are used specifically by this function.
                //@@ They are simply sent to the next function. 
            }
        }

        private static void flamespeck_new(int starttime, int endfadestart, int endfadeend, bool spazversion) {
            var flamespeck = new SpriteEvent("sb\\obl.png");
            storyboard.AddSpriteEvent(flamespeck);
            //flamespeck.fade(endfadestart,endfadeend,0,0);
            flamespeck.Color(starttime, new Colour(255, 80, 50));

            const int delay = 3000; //How long each moment takes, will most likely be 3 seconds
            const int fadetime = 2000;
            //How long it takes to start the traditional fade out, don't make this longer than delay
            const int colordelay = 750; //How long switching from orange to red takes
            var duration = endfadeend - starttime; //The presence of the flamespeck throughout existence.

            var color_loops = (int)(duration / (colordelay * 2.0)); //Discrete mathematics can suck it
            var main_loops = (int)(1.0 * duration / delay);
            var fade_loops = (int)(1.0 * duration / delay);

            const int spaz_save_count = 15; //How many positions are saved in the loop
            const int spaz_delay = 34; //Meh 
            var spaz_loopcount = duration / ((spaz_save_count - 1) * spaz_delay); //How many loops to spaz for


            //Color Loop
            var loop = flamespeck.CreateLoop(starttime, color_loops);
            loop.Color(0, colordelay, None, new Colour(255, 170, 50), new Colour(255, 20, 20), new Colour(255, 170, 50));

            //Fade Loop
            loop = flamespeck.CreateLoop(starttime, fade_loops);
            loop.Fade(0, 1);
            loop.Fade(fadetime, delay, None, 1, 0);

            for (var i = 0; i < main_loops; i++) {
                var curtime = starttime + i * delay;
                //Scaling, 0.6x to 0.15x
                if (!spazversion) {
                    flamespeck.Scale(curtime, randdiv(15, 60, 100));
                }
                flamespeck.Move(curtime, curtime + delay, None,
                    new Position(rand.Next(50, 990) - 200, 550),
                    new Position(rand.Next(50, 990) - 200, rand.Next(100, 440)));
            }

            if (!spazversion) return;

            loop = flamespeck.CreateLoop(starttime, spaz_loopcount);
            for (var i = 0; i < spaz_save_count; i++) {
                loop.ScaleVector(i * spaz_delay, new Position(randdiv(5, 60, 100), randdiv(5, 60, 100)));
                loop.Rotate(i * spaz_delay, randdiv(0, 628, 100));
            }
        }

        private static void titledrop(int time, int endtime, int lfmd_low, int lfmd_high, int letter_othernumber, int intensity, int rainbow) {
            var spd1 = rand.Next(lfmd_low, lfmd_high);
            var spd2 = rand.Next(lfmd_low, lfmd_high);
            var spd3 = rand.Next(lfmd_low, lfmd_high);
            var spd4 = rand.Next(lfmd_low, lfmd_high);
            var spd5 = rand.Next(lfmd_low, lfmd_high);
            var spd6 = rand.Next(lfmd_low, lfmd_high);
            var spd7 = rand.Next(lfmd_low, lfmd_high);
            var spd8 = rand.Next(lfmd_low, lfmd_high);
            var spd9 = rand.Next(lfmd_low, lfmd_high);
            var spd10 = rand.Next(lfmd_low, lfmd_high);
            var spd11 = rand.Next(lfmd_low, lfmd_high);
            var spd12 = rand.Next(lfmd_low, lfmd_high);
            var spd13 = rand.Next(lfmd_low, lfmd_high);
            var spd14 = rand.Next(lfmd_low, lfmd_high);
            var spd15 = rand.Next(lfmd_low, lfmd_high);
            var spd16 = rand.Next(lfmd_low, lfmd_high);
            var spd17 = rand.Next(lfmd_low, lfmd_high);
            var spd18 = rand.Next(lfmd_low, lfmd_high);

            letterPass(time, endtime, letter_othernumber, intensity, rainbow, spd1, spd2, spd3, spd4, spd5, spd6, spd7, spd8, spd9, spd10, spd11, spd12, spd13, spd14, spd15, spd16, spd17, spd18);
        }

        private static void letterPass(int time, int endtime, int letter_othernumber, int intensity, int rainbow, int spd1, int spd2, int spd3, int spd4, int spd5, int spd6, int spd7, int spd8, int spd9, int spd10, int spd11, int spd12, int spd13, int spd14, int spd15, int spd16, int spd17, int spd18) {
            var row_x = 75;
            var row_y = 118;

            float fadval;

            if (intensity != 0) {
                fadval = 0.4f / intensity + 0.2f;
            }
            else {
                fadval = 1;
            }

            newLetter("sb/lt/letter_u.png", spd1, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow);
            row_x = row_x + 50;
            newLetter("sb/lt/letter_n.png", spd2, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 2);
            row_x = row_x + 50;
            newLetter("sb/lt/letter_d.png", spd3, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 3);
            row_x = row_x + 50;
            newLetter("sb/lt/letter_e.png", spd4, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 4);
            row_x = row_x + 50;
            newLetter("sb/lt/letter_r.png", spd5, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 5);
            row_x = row_x + 50;
            newLetter("sb/lt/letter_w.png", spd6, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 6);
            row_x = row_x + 53;
            newLetter("sb/lt/letter_o.png", spd7, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow);
            row_x = row_x + 50;
            newLetter("sb/lt/letter_r.png", spd8, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 2);
            row_x = row_x + 50;
            newLetter("sb/lt/letter_l.png", spd9, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 3);
            row_x = row_x + 50;
            newLetter("sb/lt/letter_d.png", spd10, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 4);
            row_x = row_x + 50;

            row_x = 105;
            row_y = 198;

            newLetter("sb/lt/letter_m.png", spd11, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 2);
            row_x = row_x + 60;
            newLetter("sb/lt/letter_o.png", spd12, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 3);
            row_x = row_x + 50;
            newLetter("sb/lt/letter_n.png", spd13, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 4);
            row_x = row_x + 50;
            newLetter("sb/lt/letter_a.png", spd14, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 5);
            row_x = row_x + 50;
            newLetter("sb/lt/letter_r.png", spd15, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 6);
            row_x = row_x + 50;
            newLetter("sb/lt/letter_c.png", spd16, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow);
            row_x = row_x + 50;
            newLetter("sb/lt/letter_h.png", spd17, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 2);
            row_x = row_x + 50;
            newLetter("sb/lt/letter_y.png", spd18, time, endtime, row_x, row_y, fadval, letter_othernumber, intensity, rainbow * 3);
            row_x = row_x + 50;

            if (intensity != 0) {
                letterPass(time, endtime, letter_othernumber, intensity - 1, rainbow, spd1, spd2, spd3, spd4, spd5, spd6, spd7, spd8, spd9, spd10, spd11, spd12, spd13, spd14, spd15, spd16, spd17, spd18);
            }
        }

        private static AnimationEvent newLetter(string letter, int spd, int time, int endtime, int xpos, int ypos, float fadval, int letter_othernumber, int intensity, int rainbow) {
            var ltr = new AnimationEvent(letter, letter_othernumber, spd, Background, BottomLeft);
            storyboard.AddSpriteEvent(ltr);
            formatletterfade(time, endtime, ltr, fadval);

            if (intensity != 0) {
                ltr.Scale(time, (float)(1 + intensity / 6.0));
                spazletter(ltr, time, endtime, xpos, ypos, intensity);
            }
            else {
                ltr.Move(time, new Position(xpos, ypos));
            }

            if (rainbow > 0) {
                var cur_rainbow = rainbow;
                const int cdelay = 150;
                var loopcount = (int)((endtime - time) / (cdelay * 6.0));
                var finalstart = time + loopcount * cdelay * 6;


                byte clr1 = 255;
                byte clr2 = 255;
                byte clr3 = 255;
                byte clr4 = 255;
                byte clr5 = 255;
                byte clr6 = 255;

                var loop = ltr.CreateLoop(time, loopcount);

                for (var i = 0; i < 6; i++) {
                    clr1 = 255;
                    clr2 = 255;
                    clr3 = 255;
                    clr4 = 255;
                    clr5 = 255;
                    clr6 = 255;

                    if (cur_rainbow == 1) {
                        clr2 = 0;
                        clr3 = 0;
                        clr6 = 0;
                    }
                    else if (cur_rainbow == 2) {
                        clr3 = 0;
                        clr4 = 0;
                        clr6 = 0;
                    }
                    else if (cur_rainbow == 3) {
                        clr1 = 0;
                        clr3 = 0;
                        clr4 = 0;
                    }
                    else if (cur_rainbow == 4) {
                        clr1 = 0;
                        clr4 = 0;
                        clr5 = 0;
                    }
                    else if (cur_rainbow == 5) {
                        clr1 = 0;
                        clr2 = 0;
                        clr5 = 0;
                    }
                    else if (cur_rainbow == 6) {
                        clr2 = 0;
                        clr5 = 0;
                        clr6 = 0;
                    }

                    loop.Color(i * cdelay, (i + 1) * cdelay, None, new Colour(clr1, clr2, clr3), new Colour(clr4, clr5, clr6));
                    cur_rainbow = cur_rainbow + 1;
                    if (cur_rainbow == 7) {
                        cur_rainbow = 1;
                    }
                }


                ltr.Color(finalstart, endtime, None, new Colour(clr4, clr5, clr6), Colour.White);

            }


            return ltr;
        }

        private static void spazletter(SpriteEvent letter, int time, int endtime, int xpos, int ypos, int intensity) {
            var duration = endtime - time; // Length of whole operation
            const int delay = 50; // Each frame length of shake
            const int loopsize = 20; //Stored frames
            const int repeatlength = delay * loopsize; //How long it takes a full loop to go
            var loopcount = (int)(1.0 * duration / repeatlength); //Number of times the main loop will go
            var intensityscale = intensity * 5;
            int new_x;
            int new_y;

            const int add_x = -2;
            const int add_y = 6;


            //Main spaz loop
            var loop = letter.CreateLoop(time, loopcount);

            for (var i = 0; i <= loopsize; i++) {
                new_x = rand.Next(xpos - intensityscale, xpos + intensityscale);
                new_y = rand.Next(ypos - intensityscale, ypos + intensityscale);
                loop.Move(i * delay, new Position(new_x + add_x, new_y + add_y));
            }


            //Final bits outside of the loop
            var curtime = time + loopcount * repeatlength;
            duration = endtime - curtime;
            var finalloopcount = (int)(1.0 * duration / delay);

            for (var i = 0; i < finalloopcount; i++) {
                new_x = rand.Next(xpos - intensityscale, xpos + intensityscale);
                new_y = rand.Next(ypos - intensityscale, ypos + intensityscale);

                letter.Move(curtime, new Position(new_x + add_x, new_y + add_y));

                curtime = curtime + delay;
            }

        }

        private static void formatletterfade(int time, int endtime, ITransformable letter, float fadval) {
            letter.Fade(time, fadval);
            letter.Fade(endtime, 0);
        }

        private static void newpellet(int xpos, int ypos, float xscale, float yscale, int time, float rot) {
            var pellet = new SpriteEvent("sb\\pel1.png");
            storyboard.AddSpriteEvent(pellet);
            const Easing easing = In;
            const int tweentime = 700;
            const double xburstmulti = 1.2;
            const double yburstmulti = 2.0;
            const int rs_min = -30;
            const int rs_max = 30;
            pellet.Fade(time, 1);
            pellet.Fade(52546, 0);
            //pellet.move(time,xpos,ypos); //Will be overridden later
            pellet.ScaleVector(time, time + tweentime, easing, new Position(xscale, yscale), new Position(0.4f));
            if (rot != 0) {
                pellet.Rotate(time, time + tweentime, easing, rot, 0);
            }
            const double ref_x = 320.0;
            const double ref_y = 240.0;

            float dest_x = 0;
            float dest_y = ypos - (float)((ref_y - ypos) / yburstmulti);

            if (xpos <= ref_x) {
                dest_x = xpos - (float)((ref_x - xpos) / xburstmulti);
            }
            else {
                dest_x = xpos + (float)((xpos - ref_x) / xburstmulti);
            }

            dest_x = dest_x + rand.Next(rs_min, rs_max);
            dest_y = dest_y + rand.Next(rs_min, rs_max);

            pellet.Move(time, time + tweentime, In, new Position(xpos, ypos), new Position(dest_x, dest_y));

            //Make a new pellet to ease 2 into the heart LOL
            attackpellet(52546, 53732, dest_x, dest_y);
        }

        private static void attackpellet(int time, int endtime, float xpos, float ypos) {
            var pellet = new AnimationEvent("sb/pel.png", 2, 100);
            storyboard.AddSpriteEvent(pellet);
            pellet.Scale(time, 0.4f);
            pellet.Fade(time, 1);
            pellet.Move(time, endtime, Out, new Position(xpos, ypos), new Position(320, 335));
            pellet.Fade(endtime, 0);
        }

        private static void new_slice(string image, int xpos, int ypos, int left) {
            var imagename = "sb/ct/" + image + ".png"; //Append

            var letter = new SpriteEvent(imagename, Background, BottomLeft);
            storyboard.AddSpriteEvent(letter);
            const int starttime = 430004;
            const int endtime = 432082;
            const int addendum = 0;
            const int xposmodmin = 100;
            const int xposmodmax = 210;
            letter.Move(starttime, new Position(xpos, ypos));
            letter.MoveY(starttime + addendum, endtime + addendum, Out, ypos, rand.Next(1150, 1250));
            letter.Fade(starttime, 1);
            letter.Fade(starttime + addendum, 430682, Out, 1, 0);

            if (left == 1) {
                letter.MoveX(starttime + addendum, endtime + addendum, In, xpos, xpos - rand.Next(xposmodmin, xposmodmax));
            }
            else {
                letter.MoveX(starttime + addendum, endtime + addendum, In, xpos, xpos + rand.Next(xposmodmin, xposmodmax));
            }
            var sign = rand.Next(0, 1);

            if (sign == 0) {
                sign = -1;
            }
            else {
                sign = 1;
            }

            letter.Rotate(starttime + addendum, endtime + addendum, In, 0, sign * randdiv(500, 4600, 1000));
        }



        private static void torheartshake(SpriteEvent torheart, int time, int endtime, int xbound, int ybound, double delay, int store) {
            var duration = endtime - time;
            var shakes = (int)(duration / delay);
            var remainder = shakes % (store - 1);
            var loopcount = (int)(shakes / (store - 1));
            //Store is number of shakes recorded into a loop
            var loop = torheart.CreateLoop(time, loopcount);
            for (var i = 0; i < store; i++) {
                loop.Move((int)(i * delay), new Position(tor_pickrandom_n(320, xbound), tor_pickrandom_n(176, ybound)));
            }
            var curtime = time + (shakes - remainder) * delay;
            for (var i = 0; i < remainder; i++) {
                torheart.Move((int)curtime, new Position(tor_pickrandom_n(320, xbound), tor_pickrandom_n(176, ybound)));
                curtime = curtime + delay;
            }
        }

        private static int tor_pickrandom_n(int npos, int nbound) {
            return rand.Next(npos - nbound, npos + nbound);
        }

        private static void torheartspam(int time, int xpos, int ypos, int amount, int minheight, int maxheight, int x_min, int x_max, double yspeed, int left) {
            for (var i = 0; i < amount; i++) {
                var horspeed = rand.Next(x_min, x_max) / 1000.0;
                if (left == 1) {
                    horspeed = -horspeed;
                }
                torheartshatter(time, xpos, ypos, rand.Next(minheight, maxheight), horspeed, yspeed);
            }
        }

        private static void torheartshatter(int time, int xpos, int ypos, int maxheight, double horspeed, double vspeed) {
            var shatter = new AnimationEvent("sb/torshatter.png", 4, 176);
            storyboard.AddSpriteEvent(shatter);
            shatter.Scale(time, 0.4f);

            if (horspeed > 0) {
                //Exit to the right
                shatter.MoveX(time, (int)(time + (2000 - xpos) / horspeed), None, xpos, 2000);
            }
            else {
                //Exit to the left
                shatter.MoveX(time, time + (int)(-1.0 * (2000 + xpos) / horspeed), None, xpos, -2000);
            }

            var delay = (ypos - maxheight) / vspeed;
            shatter.MoveY(time, (int)(time + delay), In, ypos, maxheight);
            shatter.MoveY((int)(time + delay), (int)(time + delay + delay), Out, maxheight, ypos);

            delay = time + delay + delay; //Now delay isn't a delay...

            var newvspeed = vspeed * 2; //Trying to get the maximum speed from easing, is this a parabola?
                                        //I'm not very good at stuff really. It might be 2x due to derived x squared...

            shatter.MoveY((int)delay, (int)(delay + (1200 - ypos) / newvspeed), None, ypos, 1200);
        }



        static float randdiv(int a, int b, float c) {
            return (float)(1.0 * rand.Next(a, b) / c);
        }
    }
}