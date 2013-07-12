INPUT in1;
INPUT in2;

OUTPUT aggOut;
OUTPUT detOut;

strm1 = FILTER in1 WHERE temperature > 60;

strm2 = TRANSFORM in2
        WITH a                       AS a,
             b                       AS b,
             BCC.toLowerCase(text)   AS text,
             !BCC.isEmpty(mediaList) AS hasMedia,
             (x + y + z) / 3         AS temp;

strm3 = FILTER strm2 WHERE temp > 60;

strm4 = MERGE strm1, strm3
        WITH (strm1.a, strm2.a)                 AS a,
             (strm1.b, strm2.b)                 AS b,
             (strm1.text)                       AS text,
             (strm1.hasMedia, false)            AS hasMedia,
             (strm1.temperature, strm2.temp)    AS temperature;

detOut = FILTER strm4 WHERE hasMedia;

aggOut = GROUP strm4 BY a, b SAMPLERATE 5
         AGG BCC.count("MIN")               AS numPoints,
             BCC.avg("MIN", temperature)    AS avgTemp,
             BCC.latest(text)               AS lastMsg;
