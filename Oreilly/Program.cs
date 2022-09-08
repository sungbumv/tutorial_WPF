﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreilly // 네임스페이스 
{
    // private(사설), public(공용), protected(보호), internal(내부) 은 접근한정자 키워드
    internal class Program
    {
        static void Main(string[] args) // Main Method  ->  C#은 Main이라는 이름의 메서드를 기본 진입점(entry point)로 본다. 반환형 타입은 int, string 등 다양해질 수 있다.
        { // { } : block
            Console.WriteLine(FeetToInches(30));    // 여기서 30 = Literals(리터럴)
        }

        static int FeetToInches(int feet)  
        {
            int inches = feet * 12;
            return inches;
        }
    }
}
