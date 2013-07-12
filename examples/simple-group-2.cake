INPUT in;
OUTPUT out;

out = GROUP in BY TIMEONLY SAMPLERATE 60
      AGG BCC.sum("MIN", x) AS sumX,
          BCC.count("ALL") AS countAll
          BCC.avg("MIN",x) AS avgPerMinute;
