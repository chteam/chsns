<template>
  <div class="min-h-screen bg-gray-50">
    <nav class="bg-white shadow-sm">
      <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div class="flex justify-between h-16">
          <div class="flex items-center">
            <h1 class="text-2xl font-bold text-gray-900">CHSNS</h1>
          </div>
          <div class="flex items-center space-x-4">
            <NuxtLink to="/" class="text-gray-700 hover:text-gray-900 px-3 py-2">Home</NuxtLink>
            <NuxtLink to="/about" class="text-gray-700 hover:text-gray-900 px-3 py-2">About</NuxtLink>
          </div>
        </div>
      </div>
    </nav>
    
    <main>
      <slot />
    </main>
    
    <footer class="bg-white border-t mt-auto">
      <div class="max-w-7xl mx-auto py-6 px-4 sm:px-6 lg:px-8">
        <p class="text-center text-gray-500 text-sm">
          © 2024 CHSNS - Developed by CHTeam (成幻小组)
        </p>
      </div>
    </footer>
  </div>
</template>

<script setup lang="ts">
</script>
