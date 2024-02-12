<template>
  <div class="container">
    <section class="row" v-if="cult">
      <!-- {{ cult }} -->
      <img :src="cult.coverImg" alt="">
      <h1>{{ cult.name }}</h1>
      <p>{{ cult.bio }}</p>
      <div class="col-1">
        <img class="img-fluid" :src="cult.leader.picture" alt="">
      </div>
      <div class="col-5">
        <span>{{ cult.leader.name }}</span>
      </div>
      <div class="col-6 text-end">
        <button v-if="cult.leaderId == account.id" class="btn btn-danger" @click="deleteCult()">Delete Cult<i class="mdi mdi-delete-forever"></i></button>
      </div>
    </section>
    <section v-else class="text-center fs-1">
      <i class="mdi mdi-loading mdi-spin text-info">loading...</i>
    </section>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { cultsService } from '../services/CultsService.js';
import { useRoute, useRouter } from 'vue-router';
export default {
  setup(){
    const route = useRoute() // route is where you are (destination)
    const router = useRouter() // router is the vehicle that moves you
    onMounted(()=>{
      getCultById()
    })
    async function getCultById(){
      try {
        await cultsService.getCultById(route.params.cultId)
      } catch (error) {
        Pop.error(error,  '[GET CULT BY ID]')
        router.push({name: 'Home'})
      }
    }
  return {
    account: computed(()=> AppState.account),
    cult: computed(()=> AppState.activeCult),
    async deleteCult(){
      try {
        const confirm = await Pop.confirm("ARE YOU SURE YOU WANT TO DELeTE THIS?!")
        if(!confirm) return
        await cultsService.deleteCult(route.params.cultId)
        router.push({name: 'Home'})
        Pop.success('delete cult')

      } catch (error) {
        Pop.error(error, '[DELETE CULT]')
      }
    }
  }
  }
};
</script>


<style lang="scss" scoped>

</style>
