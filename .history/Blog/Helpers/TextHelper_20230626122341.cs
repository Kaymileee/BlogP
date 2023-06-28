using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blog.Helpers
{
  public class TextHelper
  {
    public static string ToUnsignedString(string input)
    {
      string slug = input.ToLower().Trim();
      slug = System.Text.RegularExpressions.Regex.Replace(slug, @"[^a-z0-9\s-]", "");
      slug = System.Text.RegularExpressions.Regex.Replace(slug, @"\s+", " ");
      slug = slug.Replace(" ", "-");
      return slug;
    }
  }
}