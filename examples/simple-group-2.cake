INPUT in;
OUTPUT out;

out = GROUP in BY TIMEONLY SAMPLERATE 60
      AGG FC.sum("MIN", x) AS sumX,
          FC.count("ALL") AS countAll
          FC.avg("MIN",x) AS avgPerMinute;
