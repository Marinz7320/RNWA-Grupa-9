const {
  GraphQLObjectType,
  GraphQLInt,
  GraphQLString,
  GraphQLList,
} = require("graphql");
const { dbQuery } = require("../database");
const LanguageType = require("./Airplane.js");

const LanguageType = new GraphQLObjectType({
  name: "LanguageType",
  fields: () => ({
    language_id: { type: GraphQLInt },
    language_code: { type: GraphQLInt },
    language_name: { type: GraphQLString },
    language: {
      type: LanguageType,
      resolve: async (post) => {
        let res = await dbQuery(
          `SELECT * FROM language WHERE language_id = ${parseInt(
            post.language_id
          )}`
        );
        return res[0];
      },
    },
  }),
});

module.exports = LanguageType;
