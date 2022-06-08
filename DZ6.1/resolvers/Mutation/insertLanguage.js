const { GraphQLString } = require("graphql");
const { dbQuery } = require("../../database");
const LanguageType = require("../../types/LanguageType");

const insertLanguage = {
  type: LanguageType,
  args: {
    language_code: { type: GraphQLString },
    language_name: { type: GraphQLString },
  },
  async resolve(_, { language_code, language_name }) {
    let res = await dbQuery(
      `insert into language (language_code, language_name) values ('${language_code}', '${language_name}')`
    );
    return { id: res.language_id, language_code, language_name };
  },
};

module.exports = insertLanguage;
