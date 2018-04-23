﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.Anonymizer.Models
{
	public class RegexPattern
	{
		public string Pattern { get; set; }
		public string Description { get; set; }
		public bool ShouldEncrypt { get; set; }
		public bool ShouldEnable { get; set; }
		public bool IsDefaultPath { get; set; }
		public string Id { get; set; }
	}
}