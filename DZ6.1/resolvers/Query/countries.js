const { GraphQLList } = require("graphql");
const { dbQuery } = require("../../database");
const { CountryType } = require("../../types");

const fieldsCountries = {
  type: new GraphQLList(CountryType),
  async resolve(_, {}) {
    let res = await dbQuery(`SELECT * FROM country`);
    return res;
  },
};

module.exports = fieldsCountries;
