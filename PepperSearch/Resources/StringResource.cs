using System.Windows;

namespace PepperSearch
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public static class StringResource
    {
        public static string PepperHomePageLink
        {
            get
            {
                return (string)Application.Current.FindResource("pepperHomePageLink");
            }
        }

        public static string DivClassNameThread
        {
            get
            {
                return (string)Application.Current.FindResource("divClassNameThread");
            }
        }

        public static string DivClassNameThreadTitle
        {
            get
            {
                return (string)Application.Current.FindResource("divClassNameThreadTitle");
            }
        }

        public static string SpanClassNameDiscount
        {
            get
            {
                return (string)Application.Current.FindResource("spanClassNameDiscount");
            }
        }

        public static string SpanClassNameActualPrice
        {
            get
            {
                return (string)Application.Current.FindResource("spanClassNameActualPrice");
            }
        }

        public static string SpanClassNamePreviousAndDiscount
        {
            get
            {
                return (string)Application.Current.FindResource("spanClassNamePreviousAndDiscount");
            }
        }

        public static string SpanClassNamePrevioudPrice
        {
            get
            {
                return (string)Application.Current.FindResource("spanClassNamePrevioudPrice");
            }
        }

        public static string SpanClassNameDiscountPercentage
        {
            get
            {
                return (string)Application.Current.FindResource("spanClassNameDiscountPercentage");
            }
        }

        public static string DivClassNameHeaderMeta
        {
            get
            {
                return (string)Application.Current.FindResource("divClassNameHeaderMeta");
            }
        }

        public static string DivClassNameVoteBox
        {
            get
            {
                return (string)Application.Current.FindResource("divClassNameVoteBox");
            }
        }

        public static string SpanClassNameScoreHot
        {
            get
            {
                return (string)Application.Current.FindResource("spanClassNameScoreHot");
            }
        }

        public static string SpanClassNameScoreBurn
        {
            get
            {
                return (string)Application.Current.FindResource("spanClassNameScoreBurn");
            }
        }

        public static string DivClassNameThreadBody
        {
            get
            {
                return (string)Application.Current.FindResource("divClassNameThreadBody");
            }
        }

        public static string DivClassNameThreadBodySpace
        {
            get
            {
                return (string)Application.Current.FindResource("divClassNameThreadBodySpace");
            }
        }

        public static string DivClassNameBodySpace
        {
            get
            {
                return (string)Application.Current.FindResource("divClassNameBodySpace");
            }
        }

        public static string DivClassNameSpaceContent
        {
            get
            {
                return (string)Application.Current.FindResource("divClassNameSpaceContent");
            }
        }

        public static string ButtonContentRefresh
        {
            get
            {
                return (string)Application.Current.FindResource("buttonContentRefresh");
            }
        }

        public static string DivClassNameUserHtml
        {
            get
            {
                return (string)Application.Current.FindResource("divClassNameUserHtml");
            }
        }
    }
}
