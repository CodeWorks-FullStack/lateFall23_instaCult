import { AppState } from "../AppState.js"
import { Cult } from "../models/Cult.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"




class CultsService{
  async getCults(){
    const response = await api.get('api/cults')
    logger.log('👥', response.data)
    AppState.cults = response.data.map(cult => new Cult(cult))
  }

  async getCultById(cultId){
    AppState.activeCult = null
    let path = ['api', 'cults', cultId] // 🏴‍☠️🤯
    const response = await api.get(path.join('/'))
    logger.log('👥', response.data)
    AppState.activeCult = new Cult(response.data)
  }

  async createCult(cultData){
    const response = await api.post('api/cults', cultData)
    logger.log('👥✨', response.data)
    const newCult = new Cult(response.data)
    // AppState.cults.push(response.data) IF you don't class the data before putting in into the appstate you will get a prop type error and could cause further issues
    AppState.cults.push(newCult)
  }

  async deleteCult(cultId){
    const response = await api.delete(`api/cults/${cultId}`)
    logger.log('🗑️',response)

    AppState.activeCult = null // the delete happens on this page, so it's good to clear this too
    const indexToRemove = AppState.cults.findIndex(cult => cult.id == cultId)
    AppState.cults.splice(indexToRemove, 1)
  }
}

export const cultsService = new CultsService()
