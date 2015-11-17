# osuElements

Currently includes:
Reading Beamaps (.osu): all possible variables/settings supported.
Reading/Writing Storyboards (.osb)
Parsing events + calculating transformations
Calculating slidercurves
basic modsfunctionality (HR -> higher difficulty...)

Manager:
  hitobjects: combocolors, combonumbering
  timingpoints: bpm, sliderspeed
  get position at given time
  calculating hititmings, circlesize
  
Events:
  Parsing and writing
  Loops, triggers supported
  Sprite and Animation: get transformation at given time
  beatmap-exclusive events
