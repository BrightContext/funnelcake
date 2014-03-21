INPUT Input1;
// { "message" : "I am a happy string" }

OUTPUT stream;

stream = TAG Input1
  WITH FIELD myTag
  VALUES
    "string"
      WHERE FC.regexMatch(message, "string"),
    "happy"
      WHERE FC.regexMatch(message, "happy"),
    "firstperson"
      WHERE FC.regexMatch(message, "I am"),
    "none"
      DEFAULT
;

//
// stream
//
// {
//  "message": "I am a happy string",
//  "myTag": ["string", "happy", "firstperson"],
//  "_tstamp": "2014-03-19T20:09:54.783Z"
// }
//