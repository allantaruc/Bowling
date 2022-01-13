using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Bowling.BlazorUI.Data
{
    public class Game
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Game name is required.")]
        public string Name { get; set; }

        public List<Frame> Frames { get; set; }

        public Game()
        {
            Id = 0;
            Frames = new List<Frame>(10);
            for (int frameCount = 0; frameCount != 9; frameCount++) Frames.Add(new Frame {
                Id = frameCount + 1,
                Shots = { new Shot(), new Shot () }
            }); ;
            Frames.Add(new Frame(true)
            {
                Id = 10,
                Shots = { new Shot(), new Shot(), new Shot() }
            });
        }
    }

    public class Frame { 
        public int Id { get; set; }
        public bool IsTenth { get; set; }
        public List<Shot> Shots { get; set; }
        public Frame(bool isTenth)
        {
            IsTenth = true;
            Shots = new List<Shot>(3);
        }
        public Frame()
        {
            IsTenth = true;
            Shots = new List<Shot>(2);
        }
    }

    public class Shot {
        private string _pins;
        
        [Range(0, 10, ErrorMessage = "Pins knocked down per frame can only be 0-10")]
        public string PinsKnockedDown
        {
            get {

                return string.IsNullOrEmpty(_pins) ? "0" : _pins;
            }
            set {
                _pins = value;
            }
        }

        public int Pins {
            get {
                return string.IsNullOrEmpty(_pins) ? 0 : int.Parse(_pins);
            }
        }
    }

    public class ShotsUnderTenAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<Shot> shots = (List<Shot>)value;
            if (shots != null && shots.Count >= 2) {
                if (shots.Count < 3)
                {
                    int pins = 0;
                    shots.ForEach(shot =>
                    {
                        pins += int.Parse(shot.PinsKnockedDown);
                    });
                    if (pins > 10) return new ValidationResult("Error");
                    else return ValidationResult.Success;
                }
                else {
                    if (int.Parse(shots.FirstOrDefault().PinsKnockedDown) != 10)
                    {
                        if (int.Parse(shots[0].PinsKnockedDown) + int.Parse(shots[1].PinsKnockedDown) > 10) return new ValidationResult("Error");
                        else return ValidationResult.Success;
                    }
                    else {
                        if (int.Parse(shots[1].PinsKnockedDown) != 10)
                        {
                            if (int.Parse(shots[1].PinsKnockedDown) + int.Parse(shots[2].PinsKnockedDown) > 10) return new ValidationResult("Error");
                            else return ValidationResult.Success;
                        }
                        else {
                            if (int.Parse(shots[2].PinsKnockedDown) > 10) return new ValidationResult("Error");
                            else return ValidationResult.Success;
                        }
                    }
                }
            }
            return new ValidationResult("Error");
        }
    }
}