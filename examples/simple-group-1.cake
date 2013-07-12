INPUT in;
OUTPUT out;

out = GROUP in BY state, zipcode SAMPLERATE 5
      AGG BCC.sum("MIN", x) AS sumX,
          BCC.count("MIN") AS numMsgPerMinute,
          BCC.avg("MIN", x) AS avgMsgPerMinute;
