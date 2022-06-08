const { GraphQLObjectType, GraphQLInt } = require("graphql");

const Language = new GraphQLObjectType({
  name: "Language",
  fields: () => ({
    language_id: { type: GraphQLInt },
    language_code: { type: GraphQLInt },
    language_name: { type: GraphQLString },
  }),
});

module.exports = AirplaneType;
