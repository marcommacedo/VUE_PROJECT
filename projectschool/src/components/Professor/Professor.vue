<template>
  <div>
    <titulo texto="Professor" />

    <table>
      <thead>
        <th>Código</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="professores.length">
        <tr v-for="(professor, index) in professores" :key="index">
          <td>{{professor.id}}</td>
          <router-link
            to="/Alunos"
            tag="td"
            style="cursor: pointer;"
          >{{professor.nome}} {{professor.sobrenome}}</router-link>
          <td>1</td>
        </tr>
      </tbody>
      <tfoot v-else>Nenhum professor encontrado</tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_shared/Titulo";

export default {
  components: {
    Titulo
  },
  data() {
    return {
      professores: [
        {
          id: 1,
          nome: "Marco"
        }
      ]
    };
  }
};
</script>

<style scoped>
</style>