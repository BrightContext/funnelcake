INPUT in;
OUTPUT out;

out = GROUP in BY state, zipcode SAMPLERATE 5
      AGG FC.sum("MIN", x) AS sumX,
          FC.count("MIN") AS numMsgPerMinute,
          FC.avg("MIN", x) AS avgMsgPerMinute;
