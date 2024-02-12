<template>
    <div class="container">

        <CultForm/>

      <section class="row">

        <div v-for="cult in cults" :key="cult.id" class="col-md-4">
          <!-- {{ cult.name }} -->
          <CultCard :cult="cult"/>
        </div>


      </section>
      <!-- {{ cults }} -->

    </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';
import { cultsService } from '../services/CultsService.js';
import CultCard from '../components/CultCard.vue'
import CultForm from '../components/CultForm.vue';
export default {
  setup() {
    onMounted(()=>{
      getCults()
    })


    async function getCults(){
      try {
        await cultsService.getCults()
      } catch (error) {
        Pop.error(error, "[GET CULTS]")
      }
    }
    return {
      cults: computed(()=> AppState.cults)
    }
  },
  components: { CultCard, CultForm }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
