using MovieRecommender2022.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieRecommender2022.Data
{
    internal class XmlMovieHelper
    {
        internal static List<Movie> Load(string url = @"movies.xml")
        {
            IEnumerable<XElement>? movieElements = XElement.Load(url).Elements("movie"); //we use a full control of xml

            return movieElements.Select(x => new Movie //approach with movie elements
            {
                Title = x.Element("title").Value,
                Keywords = x.Descendants("keyword").Select(k => k.Value).ToArray(), //we select all the keywords, then select only one and text value
                Genre = Enum.Parse<GenreEnum>(x.Element("genre").Value, true)
            }).ToList(); //add Rating?
        }
    }
}
