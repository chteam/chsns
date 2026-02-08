<template>
  <div class="container mx-auto px-4 py-16">
    <div class="text-center mb-12">
      <h1 class="text-5xl font-bold text-gray-900 mb-4">
        Welcome to CHSNS
      </h1>
      <p class="text-xl text-gray-600 mb-8">
        A modern SNS web application built with Nuxt.js
      </p>
      <p class="text-lg text-gray-500">
        CHSNS是成幻小组开发的一款SNS网站应用
      </p>
    </div>

    <div class="grid grid-cols-1 md:grid-cols-3 gap-8 max-w-5xl mx-auto">
      <div class="bg-white p-6 rounded-lg shadow-md">
        <div class="text-blue-500 text-3xl mb-4">🚀</div>
        <h3 class="text-xl font-semibold mb-2">Modern Stack</h3>
        <p class="text-gray-600">
          Built with Nuxt 3, Vue 3, and TypeScript for optimal performance
        </p>
      </div>

      <div class="bg-white p-6 rounded-lg shadow-md">
        <div class="text-green-500 text-3xl mb-4">⚡</div>
        <h3 class="text-xl font-semibold mb-2">Fast & Responsive</h3>
        <p class="text-gray-600">
          Lightning-fast page loads and smooth interactions
        </p>
      </div>

      <div class="bg-white p-6 rounded-lg shadow-md">
        <div class="text-purple-500 text-3xl mb-4">🎨</div>
        <h3 class="text-xl font-semibold mb-2">Beautiful Design</h3>
        <p class="text-gray-600">
          Clean and modern UI powered by Tailwind CSS
        </p>
      </div>
    </div>

    <div class="mt-12 text-center">
      <NuxtLink 
        to="/about" 
        class="inline-block bg-blue-600 text-white px-8 py-3 rounded-lg font-semibold hover:bg-blue-700 transition"
      >
        Learn More
      </NuxtLink>
    </div>
  </div>
</template>

<script setup lang="ts">
useHead({
  title: 'Home - CHSNS'
})
</script>
