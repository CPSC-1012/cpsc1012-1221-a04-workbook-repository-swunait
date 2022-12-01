using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeObjectProblems2
{
    internal class CD
    {
        // Define backing fields for properties
        private string _title = null!;
        private Artist _artist = null!;
        private int _tracks;
        private double _price;

        // Define properties with a backing field
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title is required.");
                }
                _title = value.Trim();
            }
        }

        public Artist Artist
        {
            get => _artist;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Artist is required.");
                }
                _artist = value;
            }
        }

        public int Tracks
        {
            get => _tracks;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Invalid number of tracks (min 1 track is required)");
                }
                _tracks = value;
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be a negative value.");
                }
                _price = value;
            }
        }

        public CD(string Title, Artist Artist, int Tracks, double Price)
        {
            this.Title = Title;
            this.Artist = Artist;
            this.Tracks = Tracks;
            this.Price = Price;
        }

        public string CDInfo()
        {
            return $"{Title, -20} {Artist, -20} {Price, 8:C}";
        }
    }
}
