<template>
  <div v-if="!loading">
    <Titulo :texto="`Aluno: ${aluno.nome}`" :btnVoltar="!visualizando">
      <button v-show="visualizando" class="btn btnEditar" @click="editar()">editar</button>
    </Titulo>

    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matricula:</td>
          <td>
            <label>{{aluno.id}}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="visualizando">{{aluno.nome}}</label>
            <input v-else v-model="aluno.nome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="visualizando">{{aluno.sobrenome}}</label>
            <input v-else v-model="aluno.sobrenome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data Nascimento:</td>
          <td>
            <label v-if="visualizando">{{aluno.dataNascimento}}</label>
            <input v-else v-model="aluno.dataNascimento" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
            <label v-if="visualizando">{{aluno.professor.nome}}</label>
            <select v-else v-model="aluno.professor.id">
              <option
                v-for="(professor, index) in professores"
                :key="index"
                :value="professor.id"
              >{{aluno.professor.nome}}</option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>

    <div style="margin-top: 10px;">
      <div v-if="!visualizando">
        <button class="btn btnSalvar" @click="salvar()">salvar</button>
        <button class="btn btnCancelar" @click="cancelar()">cancelar</button>
      </div>
    </div>
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
      professores: [],
      aluno: {},
      id: this.$route.params.id,
      visualizando: true,
      loading: true
    };
  },
  created() {
    this.carregarProfessor();
  },
  methods: {
    editar() {
      this.visualizando = !this.visualizando;
    },
    salvar() {
      let _aluno = {
        id: this.aluno.id,
        nome: this.aluno.nome,
        sobrenome: this.aluno.sobrenome,
        dataNascimento: this.aluno.dataNascimento,
        professorid: this.aluno.professor.id
      };

      this.$http
        .put(`http://localhost:5000/api/aluno/${_aluno.id}`, _aluno)
        .then(res => res.json())
        .then(aluno => (this.aluno = aluno))
        .then(() => (this.visualizando = true));

      this.visualizando = !this.visualizando;
    },
    cancelar() {
      this.visualizando = !this.visualizando;
    },
    carregarProfessor() {
      this.$http
        .get("http://localhost:5000/api/professor")
        .then(res => res.json())
        .then(professores => {
          this.professores = professores;
          this.carregarAluno();
        });
    },
    carregarAluno() {
      this.$http
        .get(`http://localhost:5000/api/aluno/${this.id}`)
        .then(res => res.json())
        .then(aluno => {
          this.aluno = aluno;
          this.loading = false;
        });
    }
  }
};
</script>

<style scoped>
.btnEditar {
  float: right;
  background-color: rgb(76, 186, 249);
}

.btnSalvar {
  float: right;
  background-color: rgb(79, 196, 68);
}

.btnCancelar {
  float: left;
  background-color: rgb(249, 186, 92);
}

.colPequeno {
  width: 20%;
}

input,
select {
  margin: 0px;
  padding: 5px 10px;
  font-size: 0.9em;
  border: 1px solid silver;
  border-radius: 5px;
  font-family: Montserrat, sans-serif;
  width: 95%;
  background-color: rgb(245, 245, 245);
}

select {
  height: 38px;
  width: 100%;
}
</style>