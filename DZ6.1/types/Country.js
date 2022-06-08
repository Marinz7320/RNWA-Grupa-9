const {
  GraphQLObjectType,
  GraphQLInt,
  GraphQLString,
  GraphQLList,
} = require("graphql");
const { dbQuery } = require("../database");
const CountryType = require("./CountryType");

const PostType = new GraphQLObjectType({
  name: "Post",
  fields: () => ({
    country_id: { type: GraphQLInt },
    country_iso_code: { type: GraphQLInt },
    country_name: { type: GraphQLString },
    user: {
      type: UserType,
      resolve: async (post) => {
        let res = await dbQuery(
          `SELECT * FROM country WHERE country_id = ${parseInt(
            post.country_id
          )}`
        );
        return res[0];
      },
    },
  }),
});

module.exports = CountryType;
