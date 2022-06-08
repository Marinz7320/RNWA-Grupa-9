const { GraphQLObjectType } = require("graphql");

const fieldsCountry = require("./country");
const fieldsCountries = require("./countries");
const fieldsLanguageTypes = require("./languagetypes");
const fieldsLanguageType = require("./language");

const Query = new GraphQLObjectType({
  name: "Query",
  fields: {
    // Query one user
    country: fieldsCountry,
    // Query all users
    countries: fieldsCountries,
    // all airplanetypes
    languageTypes: fieldsLanguageTypes,
    // one airplanetype
    language: fieldsLanguageType,
  },
});

module.exports = Query;
