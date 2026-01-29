using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamIkkinchModule.Dtos;

public class CreatedMovieDto
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int DurationMinutes { get; set; }//kino vaqti m
    public double Rating { get; set; }
    public long BoxOfficeEarnings { get; set; }
}
