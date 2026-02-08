// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2024-04-03',
  devtools: { enabled: true },
  
  modules: [
    '@nuxtjs/tailwindcss'
  ],

  app: {
    head: {
      title: 'CHSNS - SNS Web Application',
      meta: [
        { charset: 'utf-8' },
        { name: 'viewport', content: 'width=device-width, initial-scale=1' },
        { name: 'description', content: 'CHSNS is a SNS web application developed by CHTeam' }
      ]
    }
  },

  css: [],

  typescript: {
    strict: true,
    typeCheck: true
  }
})
