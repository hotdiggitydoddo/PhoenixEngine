using System;

namespace Phoenix.Core
{
	public class RNG
	{
		int _seed;
		float _s0 = 0;
		float _s1 = 0;
		float _s2 = 0;
		int _c = 0;
		float _frac = 2.3283064365386963e-10;

		public int Seed 
		{ 
			get { return _seed; }
			set 
			{
				value = (value < 1 ? 1 / value : value);
				_seed = value;
				_s0 = (value >> 0) * _frac;

				value = (value * 69069 + 1) >> 0;
				_s1 = value * _frac;

				value = (value * 69069 + 1) >> 0;
				_s2 = value * _frac;

				_c = 1;
				return this;
			}
				
		}

		public RNG ()
		{
			
		}
	}
}

