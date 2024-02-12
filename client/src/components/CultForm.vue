<template>
  <form @submit.prevent="createCult()" class="row my-3">
    <div class="col-md-4">
      <label for="create-cult-name">Name of Cult</label>
      <input v-model="cultData.name" class="form-control" type="text" minlength="3" maxlength="25" required name="create-cult-name" id="create-cult-name">
    </div>
    <div class="col-md-4">
      <label for="create-cult-cover-image">Cover Image</label>
      <input v-model="cultData.coverImg" class="form-control" type="url" required maxlength="500" name="create-cult-cover-image" id="create-cult-cover-image">
    </div>
    <div class="col-md-4">
      <label for="create-cult-cover-image">Preview</label>
      <img v-if="cultData.coverImg" class="img-fluid" :src="cultData.coverImg" alt="">
    </div>
    <div class="col-md-12">
      <label for="create-cult-cover-image">Tell us about your cult</label>
      <textarea v-model="cultData.bio" required class="form-control" name="create-cult-bio"  id="create-cult-bio" rows="3"></textarea>
    </div>
    <div class="col-12 text-end">
      <button class="btn btn-primary" type="submit">Create Cult</button>
    </div>
  </form>
</template>


<script>
import {ref} from 'vue'
import Pop from '../utils/Pop.js'
import { logger } from '../utils/Logger.js'
import { cultsService } from '../services/CultsService.js'
export default {
setup(){
  const cultData = ref({})
return{
  cultData,
  async createCult(){
    try {
      logger.log('creating', cultData.value)
      await cultsService.createCult(cultData.value)
      Pop.success('Cult created')
    } catch (error) {
      Pop.error(error, "[CREATE CULT]")
    }
  }
}
}
}
</script>


<style lang="scss" scoped>

</style>
