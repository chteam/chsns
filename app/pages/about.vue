<template>
  <div class="container mx-auto px-4 py-16">
    <div class="max-w-3xl mx-auto">
      <h1 class="text-4xl font-bold text-gray-900 mb-8">About CHSNS</h1>
      
      <div class="prose prose-lg">
        <section class="mb-8">
          <h2 class="text-2xl font-semibold mb-4">What's CHSNS?</h2>
          <p class="text-gray-700 mb-4">
            CHSNS is a SNS (Social Network Service) web application that has been modernized 
            and rebuilt using Nuxt.js 3 framework. Originally developed as an ASP.NET MVC 
            application, it has been transformed into a cutting-edge web application.
          </p>
          <p class="text-gray-700">
            CHSNS是成幻小组开发的一款SNS网站应用，现已升级为基于Nuxt.js 3的现代化Web应用。
          </p>
        </section>

        <section class="mb-8">
          <h2 class="text-2xl font-semibold mb-4">Technology Stack</h2>
          <ul class="list-disc list-inside text-gray-700 space-y-2">
            <li>Nuxt.js 3 - The Intuitive Vue Framework</li>
            <li>Vue 3 - Progressive JavaScript Framework</li>
            <li>TypeScript - Type-safe development</li>
            <li>Tailwind CSS - Utility-first CSS framework</li>
          </ul>
        </section>

        <section class="mb-8">
          <h2 class="text-2xl font-semibold mb-4">About CHTeam</h2>
          <p class="text-gray-700 mb-4">
            Developed by CHTeam (成幻小组)
          </p>
          <p class="text-gray-700">
            If you have good ideas or suggestions, you can email us at:
            <a href="mailto:chsword@126.com" class="text-blue-600 hover:underline">
              chsword@126.com
            </a>
          </p>
        </section>

        <section>
          <h2 class="text-2xl font-semibold mb-4">Version History</h2>
          <ul class="list-disc list-inside text-gray-700 space-y-2">
            <li>CHSNS 3.0 - Modern Nuxt.js application (Current)</li>
            <li>CHSNS 2.0 - Enhanced features</li>
            <li>CHSNS 1.X - Initial versions</li>
          </ul>
        </section>
      </div>

      <div class="mt-12 text-center">
        <NuxtLink 
          to="/" 
          class="inline-block bg-gray-600 text-white px-8 py-3 rounded-lg font-semibold hover:bg-gray-700 transition"
        >
          Back to Home
        </NuxtLink>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
useHead({
  title: 'About - CHSNS'
})
</script>
