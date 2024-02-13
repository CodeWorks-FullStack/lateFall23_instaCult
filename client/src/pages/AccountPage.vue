<template>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div>
  <div class="container">
    <section class="row">
        <div v-for="cult in accountCults" :key="cult.id" class="col-6">
          <CultCard :cult="cult"/>
          <span>Membership #: {{ cult.cultMemberId }}</span>
        </div>
    </section>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import Pop from '../utils/Pop.js';
import { cultMembersService } from '../services/CultMembersService.js';
import CultCard from '../components/CultCard.vue';
export default {
    setup() {
        onMounted(() => {
            // getMyCultsImAMemberOf()
            // REVIEW note we could ask for this here, but that means we have to travel to this page to have this information, what if we want this info on other pages too?
        });
        async function getMyCultsImAMemberOf() {
            try {
                await cultMembersService.getMyCults();
            }
            catch (error) {
                Pop.error(error);
            }
        }
        return {
            account: computed(() => AppState.account),
            accountCults: computed(() => AppState.accountCults)
        };
    },
    components: { CultCard }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
