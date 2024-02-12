<template>
  <!-- 👥 Cult Card {{ cult.name }} -->
  <RouterLink :to="{path: `cult/${cult.id}`}">
    <div class="card">
      <img :src="cult.coverImg" alt="cover image for the cult">
      <h2>{{ cult.name }}</h2>
      <div class="d-flex justify-content-end align-items-center">
        <span class="me-2 fw-bold">{{ cult.leader.name }}</span>
        <img class="profile-img rounded-circle" :src="cult.leader.picture" :alt="`image of our devote leader ${cult.leader.name}`">
      </div>
    </div>
  </RouterLink>
</template>


<script>
import { Cult } from '../models/Cult.js';

export default {
  props: {cult: {type: Cult, required: true}},
setup(){
return{}
}
}
</script>


<style lang="scss" scoped>
.profile-img{
  height: 50px;
  width: 50px;
  object-fit: cover;
}
</style>
