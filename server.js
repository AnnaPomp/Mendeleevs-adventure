const express =require ('express');
const keys=require('./config/keys.js');
const bodyParser=require('body-parser');
const app=express();

app.use(bodyParser.urlencoded({extended:false}));
const mongoose = require('mongoose');
mongoose.connect(keys.mongoURI,{useNewUrlParser:true, useUnifiedTopology:true});


//setup database
require('./model/Account.js');
//setup the routes
require('./routes/authenticationroutes.js')(app);

app.listen(keys.port, ()=>{
console.log("Listening on" + keys.port);
});