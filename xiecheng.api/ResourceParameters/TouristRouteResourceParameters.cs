using System.Text.RegularExpressions;

namespace xiecheng.api.ResourceParameters;

public class TouristRouteResourceParameters
{
    public string? Keyword { get; set; }

    public string? RatingOperator { get; set; }
    public int? RatingValue { get; set; }
    private string _rating;

    public string? Rating
    {
        get { return _rating;} //获得_rating的值
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                Regex regex = new Regex(@"([A-Za-z0-9\-]+)(\d+)");
                string operatorType = string.Empty;
                int ratingRalue = -1;
                Match match = regex.Match(value);
                if (match.Success)
                {
                    RatingOperator = match.Groups[1].Value;
                    RatingValue = Int32.Parse(match.Groups[2].Value);
                }
                _rating = value;    //value属性接收外界数据
            }
        }
    }
}