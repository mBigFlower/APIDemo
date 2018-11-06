/**
 * 
 */
var mongoose = require('mongoose');




var ItemSchema = new mongoose.Schema({
	key: String,
	level: Number,
	content: String,
	isNecessary: Boolean,
	introduce: String,
	
});
	
var ApiSchema = new mongoose.Schema({          
    name: String,              
    category: String,                 
    description: String,               
    updateData: Date,
	items: [ItemSchema]
});




module.exports = ApiSchema;