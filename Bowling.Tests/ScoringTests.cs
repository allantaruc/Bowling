using Bowling.Domain;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace Bowling.Tests
{
    public class ScoringTests
    {
        [Theory]
        [InlineData(6, 3, 9)]
        public void ValidIncompleteFrame(int firstShot, int secondShot, int expected)
        {
            var game = new Game()
            {
                Frames = new List<Frame>() {
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = 0
                            },
                            new Shot
                            {
                                PinsKnockedDown = 0
                            }
                        }
                    }
                    ,
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = 0
                            },
                            new Shot
                            {
                                PinsKnockedDown = 0
                            }
                        }
                    }
                    ,
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = 0
                            },
                            new Shot
                            {
                                PinsKnockedDown = 0
                            }
                        }
                    }
                    ,
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = 0
                            },
                            new Shot
                            {
                                PinsKnockedDown = 0
                            }
                        }
                    }
                    ,
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = 0
                            },
                            new Shot
                            {
                                PinsKnockedDown = 0
                            }
                        }
                    }
                    ,
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = 0
                            },
                            new Shot
                            {
                                PinsKnockedDown = 0
                            }
                        }
                    }
                    ,
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = 0
                            },
                            new Shot
                            {
                                PinsKnockedDown = 0
                            }
                        }
                    }
                    ,
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = 0
                            },
                            new Shot
                            {
                                PinsKnockedDown = 0
                            }
                        }
                    }
                    ,
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = 0
                            },
                            new Shot
                            {
                                PinsKnockedDown = 0
                            },
                            new Shot
                            {
                                PinsKnockedDown = 0
                            }
                        }
                    }
                }
            };
            
            int score = game.CalculateScore();

            score.Should().Be(expected);

        }

        [Theory]
        [InlineData(9, 1, 6, 3, 9, 1, 8, 1, 7, 3, 5, 1, 8, 1, 1, 2, 3, 4, 5, 5, 1, 103)]
        public void ValidSpareFrames(int firstShot1,
            int secondShot1,
            int firstShot2,
            int secondShot2,
            int firstShot3,
            int secondShot3,
            int firstShot4,
            int secondShot4,
            int firstShot5,
            int secondShot5,
            int firstShot6,
            int secondShot6,
            int firstShot7,
            int secondShot7,
            int firstShot8,
            int secondShot8,
            int firstShot9,
            int secondShot9,
            int firstShot10,
            int secondShot10,
            int thirdShot10,
            int expected)
        {

            var game = new Game
            {
                Frames = new List<Frame>(10)
                {
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot1
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot1
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot2
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot2
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot3
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot3
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot4
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot4
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot5
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot5
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot6
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot6
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot7
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot7
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot8
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot8
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot9
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot9
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot10
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot10
                            },
                            new Shot {
                                PinsKnockedDown = thirdShot10
                            }
                        }
                    }
                }
            };

            int score = game.CalculateScore();

            score.Should().Be(expected);

        }

        [Theory]
        [InlineData(6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 10, 100)]
        public void ValidOpenFrameGame(int firstShot1,
            int secondShot1,
            int firstShot2,
            int secondShot2,
            int firstShot3,
            int secondShot3,
            int firstShot4,
            int secondShot4,
            int firstShot5,
            int secondShot5,
            int firstShot6,
            int secondShot6,
            int firstShot7,
            int secondShot7,
            int firstShot8,
            int secondShot8,
            int firstShot9,
            int secondShot9,
            int firstShot10,
            int secondShot10,
            int thirdShot10,
            int expected)
        {
            var game = new Game
            {
                Frames = new List<Frame>(10)
                {
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot1
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot1
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot2
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot2
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot3
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot3
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot4
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot4
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot5
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot5
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot6
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot6
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot7
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot7
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot8
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot8
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot9
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot9
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot10
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot10
                            },
                            new Shot {
                                PinsKnockedDown = thirdShot10
                            }
                        }
                    }
                }
            };

            int score = game.CalculateScore();

            score.Should().Be(expected);

        }

        [Theory]
        [InlineData(9, 1, 6, 3, 10, 10, 5, 4, 6, 3, 10, 9, 1, 9, 0, 10, 9, 1, 155)]
        public void ValidStrikeFrames(int firstShot1,
            int secondShot1,
            int firstShot2,
            int secondShot2,
            int firstShot3,
            int firstShot4,
            int firstShot5,
            int secondShot5,
            int firstShot6,
            int secondShot6,
            int firstShot7,
            int firstShot8,
            int secondShot8,
            int firstShot9,
            int secondShot9,
            int firstShot10,
            int secondShot10,
            int thirdShot10,
            int expected)
        {
            var game = new Game
            {
                Frames = new List<Frame>(10)
                {
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot1
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot1
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot2
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot2
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot3
                            },
                            new Shot
                            {
                                PinsKnockedDown = 0
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot4
                            },
                            new Shot
                            {
                                PinsKnockedDown = 0
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot5
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot5
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot6
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot6
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot7
                            },
                            new Shot
                            {
                                PinsKnockedDown = 0
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot8
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot8
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot9
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot9
                            }
                        }
                    },
                    new Frame {
                        Shots = new List<Shot> {
                            new Shot
                            {
                                PinsKnockedDown = firstShot10
                            },
                            new Shot
                            {
                                PinsKnockedDown = secondShot10
                            },
                            new Shot {
                                PinsKnockedDown = thirdShot10
                            }
                        }
                    }
                }
            };

            int score = game.CalculateScore();

            score.Should().Be(expected);

        }
    }
}