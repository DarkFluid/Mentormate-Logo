using System;

namespace Mentormate
{
    class Drawing
    {
        /*Breaking down the logo (example N = 3):
        ---***---***------***---***---
        --*****-*****----*****-*****--
        -***-*****-***--***-*****-***-
        ***---***---******---***---***  
        We need to print 2 M characters, but we need to create one and duplicate one right next to it.
        So we are left with this (example N = 3):
        ---***---***---
        --*****-*****--
        -***-*****-***-
        ***---***---***
        * 
        * From here we can start breaking down the letter.
        * First line has 5 sections. Three of them are '-' and 2 of them are '*'.
        *  1   2   3   4   5
        * --- *** --- *** ---
        * I will save these characters so we can easily modify the whole solution later.
        */
        private char dash = '-';
        private char star = '*';
        /*
        * Section 1 and 5 are idenctical thought the whole M.
        * The counter starts at N and the modifier for them is -1.
        * I will be using strings for every section. This isn't the most elegant way of doing this but it gets the job done.
        */
        private int numberOfEndDashes;
        private int endDashesModifier;
        private string endDashes;
        /*
         * Section 3 starts at N and modifier is -2. After we hit the mid of M it prints twice on 1 line modifier becomes 2.
         * NB: the middle is always (N + 1) / 2. After we pass the mid iteration on the loop we need to change sectors 2 3 and 4.
         */
        private int numberOfMiddleDashes;
        private int middleDashesModifier;
        private string middleDashes;
        /*
         * Sections 2 and 4 are identical as well up to the middle. They start at N and modifier is 2, until we reach (N + 1) / 2.
         * After reaching the middle they split into 2. One has a size of N and repeats until the last line. The other starts degrading by 2.
         */
        private int numberOfStars;
        private int starsModifier;

        private string stars;
        private string defaultStars;

        private int size;
        private bool middle;
        //Storing the lines. topM is b4 the middle and bottomM is after the middle.
        private string topM;
        private string bottomM;

        public Drawing(int n)
        {
            //Initializing all the variables we will need.
            numberOfEndDashes = n;
            endDashesModifier = -1;

            numberOfMiddleDashes = n;
            middleDashesModifier = -2;

            numberOfStars = n;
            starsModifier = 2;
            //We use this for the legs of M, it won't change so i hard code it.
            defaultStars = new string(star, n);
            //Saving when we pass the middle and the input.
            size = n;
            middle = false;

            
            
        }

        private void ApplyModifiers()
        {
            //Quick math to apply the modifiers.
            numberOfEndDashes += endDashesModifier;
            numberOfMiddleDashes += middleDashesModifier;
            numberOfStars += starsModifier;
            //Quick checks we don't go out of bounds.
            if (numberOfEndDashes < 0) numberOfEndDashes = 0;
            if (numberOfMiddleDashes < 0) numberOfMiddleDashes = 1;
        }

        private void ChangeModifiers()
        {
            //After we reach the middle we need to change the modifiers, quick and easy.
            middleDashesModifier = 2;
            starsModifier = -2;
            //Quick hack because at the end of the last loop we apply the modifier one extra time. We need to delete it.
            starsModifier -= 2;
        }

        private void StringUpdate(bool passedMid)
        {
            //Constructing the strings.
            endDashes = new string(dash, numberOfEndDashes);

            stars = new string(star, numberOfStars);

            middleDashes = new string(dash, numberOfMiddleDashes);

            topM = endDashes + stars + middleDashes + stars + endDashes;
            bottomM = endDashes + defaultStars + middleDashes + stars + middleDashes + defaultStars + endDashes;
        }

        private void PrintLine(bool passedMid)
        {
            //Printing our M. its double because we construct only one letter per topM or bottomM.
            if (!passedMid) Console.WriteLine($"{topM}{topM}");
            else Console.WriteLine($"{bottomM}{bottomM}");
        }

        public void DrawMentormateLogo()
        {
            //Loop that itterates n + 1 times. Quick check if we've passed the middle every loop.
            for (int i = 0; i < size + 1; i++)
            {
                if (i == (size + 1) / 2)
                {
                    middle = true;
                    ChangeModifiers();
                }
                StringUpdate(middle);
                PrintLine(middle);
                ApplyModifiers();
            }
        }
    }
}