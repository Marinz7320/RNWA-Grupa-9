const { GraphQLInt, GraphQLString, GraphQLList } = require("graphql");
const { dbQuery } = require("../../database");
const { CountryType } = require("../../types");

const fieldsCountry = {
  type: CountryType,
  args: {
    id: { type: GraphQLInt },
  },
  async resolve(_, { id }) {
    let res = await dbQuery(
      `SELECT * FROM country WHERE country_id = ${country_id}`
    );
    return res[0];
  },
};

module.exports = fieldsCountry;
