const { GraphQLObjectType } = require("graphql");
const insertAirplaneType = require("./insertLanguage");
const insertCountry = require("./insertCountry");
const insertLanguage = require("./insertLanguage");

const Mutation = new GraphQLObjectType({
  name: "mutation",
  fields: {
    // Insert a new Country
    insertCountry: insertCountry,
    // insert new Language in a movie section
    insertLanguage: insertLanguage,
  },
});

module.exports = Mutation;
