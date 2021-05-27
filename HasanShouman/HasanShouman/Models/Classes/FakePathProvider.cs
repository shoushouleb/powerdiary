using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HasanShouman.Models.Classes
{
    public class FakePathProvider : IPathProvider
    {
        public string MapPath(string path)
        {
            // Change the value of this variable, when changing the directory of the project in order for the unit-test to run.
            string fakePath = @"P:\Work\JOB\Tests\PowerDiary\HasanShouman\HasanShouman.Tests\";
            return Path.Combine(fakePath, path.Replace("~/", ""));
        }
    }
}