using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Blog.Data.Entities;
using Blog.Helpers;
using Blog.Models;
using Blog.Models.EF;
using Microsoft.VisualBasic.FileIO;

namespace Blog.Services
{
  public class CategoryService : ICategoryService
  {
    private readonly ApplicationDBContext _context;

    public CategoryService(ApplicationDBContext context)
    {
      _context = context;
    }

    public List<CategoryFromCSV> GetData(string filePath)
    {
      using (TextFieldParser parser = new TextFieldParser(filePath))
      {
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");

        // skip the header line
        parser.ReadLine();
        int idCounter = 1;

        List<CategoryFromCSV> dataList = new List<CategoryFromCSV>();
        while (!parser.EndOfData)
        {
          string[] fields = parser.ReadFields();
          CategoryFromCSV data = new CategoryFromCSV();
          data.Id = int.Parse(fields[0]);
          data.Title = fields[1];
          data.Body = fields[2];
          data.Tags = fields[3].Split(new char[] { '<', '>' }, StringSplitOptions.RemoveEmptyEntries);
          data.CreationDate = DateTime.ParseExact(fields[4], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
          data.Y = fields[5];
          dataList.Add(data);
          idCounter++;
        }
        return dataList;
      }
    }
  }
}