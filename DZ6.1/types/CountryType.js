const {
  GraphQLObjectType,
  GraphQLInt,
  GraphQLString,
  GraphQLList,
} = require("graphql");

const CountryType = new GraphQLObjectType({
  name: "Country",
  fields: {
    country_id: { type: GraphQLInt },
    country_iso_code: { type: GraphQLInt },
    country_name: { type: GraphQLString },
  },
});

module.exports = CountryType;
