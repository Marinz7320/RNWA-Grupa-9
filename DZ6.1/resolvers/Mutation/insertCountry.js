const { GraphQLString } = require("graphql");
const { dbQuery } = require("../../database");
const { CountryType } = require("../../types");

const insertCountry = {
  type: CountryType,
  args: {
    country_iso_code: { type: GraphQLString },
    country_name: { type: GraphQLString },
  },
  async resolve(_, { country_iso_code, country_name }) {
    let res = await dbQuery(
      `insert into country (country_iso_code, country_name) values ('${country_iso_code}', '${country_name}')`
    );
    return { id: res.country_id, country_iso_code, country_name };
  },
};

module.exports = insertCountry;
