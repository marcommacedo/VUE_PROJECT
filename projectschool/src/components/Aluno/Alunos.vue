<template>
  <div>
    <titulo :texto="professorid != undefined ? 'Professor: ' + professor.nome : 'Todos os alunos'" />

    <div v-if="professorid != undefined">
      <input type="text" placeholder="Nome do Aluno" v-model="nome" @keyup.enter="adicionar()" />
      <button class="btn btnInput" @click="adicionar()">adicionar</button>
    </div>

    <table>
      <thead>
        <th>Matricula</th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td class="colPequeno">{{aluno.id}}</td>
          <router-link
            :to="`/alunoDetalhe/${aluno.id}`"
            tag="td"
            style="cursor: pointer;"
          >{{aluno.nome}} {{aluno.sobrenome}}</router-link>
          <td class="colPequeno">
            <button class="btn btnDanger" @click="remover(aluno)">remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center;">
            <h5>Nenhum aluno encontrado</h5>
          </td>
        </tr>
      </tfoot>
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
      titulo: "Alunos",
      professorid: this.$route.params.prof_id,
      nome: "",
      alunos: [],
      professor: {}
    };
  },
  created() {
    if (this.professorid) {
      this.carregarProfessor();

      this.$http
        .get(`http://localhost:5000/api/aluno/ByProfessor/${this.professorid}`)
        .then(res => res.json())
        .then(alunos => (this.alunos = alunos));
    } else {
      this.$http
        .get("http://localhost:5000/api/aluno")
        .then(res => res.json())
        .then(alunos => (this.alunos = alunos));
    }
  },
  props: {},
  methods: {
    adicionar() {
      let _aluno = {
        nome: this.nome,
        sobrenome: "",
        datanascimento: "",
        professorid: this.professor.id
      };

      this.$http
        .post("http://localhost:5000/api/aluno", _aluno)
        .then(res => res.json())
        .then(aluno => {
          this.alunos.push(aluno);
          this.nome = "";
        });
    },
    remover(aluno) {
      this.$http
        .delete(`http://localhost:5000/api/aluno/${aluno.id}`)
        .then(() => {
          let _index = this.alunos.indexOf(aluno);
          this.alunos.splice(_index, 1);
        });
    },
    carregarProfessor() {
      this.$http
        .get(`http://localhost:5000/api/professor/${this.professorid}`)
        .then(res => res.json())
        .then(professor => {
          this.professor = professor;
        });
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.colPequeno {
  text-align: center;
  width: 15%;
}

input {
  width: calc(100% - 195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}

.btnInput {
  width: 150px;
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  background-color: rgb(116, 115, 115);
  display: inline;
}

.btnInput:hover {
  padding: 20px;
  margin: 0px;
  border: 0;
}
</style>