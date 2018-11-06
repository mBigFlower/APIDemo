var mongoose = require('mongoose')
var ApiSchema = require('../schema/ApiSchema.js')

var Api = mongoose.model('Apis', ApiSchema)
 
module.exports = Api