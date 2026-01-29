using ExamIkkinchModule.Dtos;
using ExamIkkinchModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamIkkinchModule.Services.Extensions;

public static  class MovieDtoExtension
{
    public static int DurationMinutes(this MovieDto movieDto) 
    {
        var h = movieDto.DurationMinutes / 60;
        return h;
    }


    // chala

    //public static long BoxOfficeEarnings(this List<MovieDto> movieDtos)
    //{
    //    var summs = 0l;
    //    for (var i = 0l; i <= (movieDtos).BoxOfficeEarnings; i++)
    //    {
    //        summs += i;
    //    }
    //    return summs;
    //}

}
