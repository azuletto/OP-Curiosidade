using OpCuriosidade.Entities.PersonnelContext;
using OpCuriosidade.Entities.PersonnelContext.ValueObjects;

namespace Application.Repositories.Migrations
{
    public class LoadPersons
    {
        public static void Load(List<Person> personsDB)
        {
            var staticPersons = new List<Person>
    {
        new Person("João Silva", "joao.silva@example.com", false, new DateOnly(1985, 5, 15), true, "Rua das Flores, 123, São Paulo",
            new OtherInfos("Honestidade", "Feliz", "Cliente desde 2010", "Tecnologia")),
        new Person("Maria Santos", "maria.santos@example.com", false, new DateOnly(1990, 8, 22), true, "Avenida Brasil, 456, Rio de Janeiro",
            new OtherInfos("Respeito", "Motivada", "Preferência por e-mail", "Música")),
        new Person("Carlos Oliveira", "carlos.oliveira@example.com", false, new DateOnly(1978, 3, 10), false, "Rua São Paulo, 789, Belo Horizonte",
            new OtherInfos("Responsabilidade", null, "Solicitou newsletter", "Esportes")),
        new Person("Ana Souza", "ana.souza@example.com", false, new DateOnly(1992, 11, 5), true, "Avenida Paulista, 1011, São Paulo",
            new OtherInfos("Empatia", "Gratidão", null, "Leitura")),
        new Person("Pedro Rodrigues", "pedro.rodrigues@example.com", false, new DateOnly(1988, 7, 30), true, "Rua do Comércio, 1314, Porto Alegre",
            new OtherInfos("Trabalho em equipe", "Animado", "Indicado por amigo", "Viagens")),
        new Person("Lucia Ferreira", "lucia.ferreira@example.com", false, new DateOnly(1975, 9, 18), false, "Avenida Central, 1516, Curitiba",
            new OtherInfos(null, "Paz interior", "Cliente VIP", "Cinema")),
        new Person("Bruno Lima", "bruno.lima@example.com", false, new DateOnly(1991, 6, 25), true, "Rua Bahia, 100, Salvador",
            new OtherInfos("Persistência", "Confiante", "Novo cliente", "Culinária")),
        new Person("Fernanda Costa", "fernanda.costa@example.com", false, new DateOnly(1983, 2, 19), true, "Rua das Laranjeiras, 78, Recife",
            new OtherInfos("Autenticidade", "Animada", "Cliente recorrente", "Dança")),
        new Person("Ricardo Almeida", "ricardo.almeida@example.com", false, new DateOnly(1970, 12, 12), false, "Avenida Maranhão, 456, Teresina",
            new OtherInfos("Transparência", null, null, "Política")),
        new Person("Juliana Rocha", "juliana.rocha@example.com", false, new DateOnly(1996, 4, 3), true, "Rua Ceará, 345, Fortaleza",
            new OtherInfos("Lealdade", "Esperançosa", "Indicação", "Fotografia")),
        new Person("Eduardo Martins", "eduardo.martins@example.com", false, new DateOnly(1984, 9, 8), false, "Avenida Amazonas, 213, Manaus",
            new OtherInfos("Justiça", "Reflexivo", "Solicitou contato", "Astronomia")),
        new Person("Patrícia Nogueira", "patricia.nogueira@example.com", false, new DateOnly(1993, 10, 29), true, "Rua Belém, 919, Belém",
            new OtherInfos("Coragem", "Determinada", null, "Teatro")),
        new Person("Tiago Mello", "tiago.mello@example.com", false, new DateOnly(1987, 11, 20), true, "Rua Piauí, 101, Goiânia",
            new OtherInfos("Comprometimento", "Alegre", "Promoção ativa", "Séries")),
        new Person("Camila Mendes", "camila.mendes@example.com", false, new DateOnly(1995, 1, 15), true, "Avenida Goiás, 606, Brasília",
            new OtherInfos("Paixão", "Inspirada", "Interesse recente", "Moda")),
        new Person("Anderson Souza", "anderson.souza@example.com", false, new DateOnly(1982, 5, 9), false, "Rua Tocantins, 321, Palmas",
            new OtherInfos("Visão", null, "Antigo cliente", "Carros")),
        new Person("Aline Ribeiro", "aline.ribeiro@example.com", false, new DateOnly(1997, 8, 18), true, "Rua Acre, 77, Boa Vista",
            new OtherInfos("Paciência", "Contente", null, "Arquitetura")),
        new Person("Roberta Cunha", "roberta.cunha@example.com", false, new DateOnly(1994, 3, 27), true, "Av. das Américas, 654, Florianópolis",
            new OtherInfos("Gratidão", "Empolgada", "Fez curso", "Desenho")),
        new Person("Vinícius Braga", "vinicius.braga@example.com", false, new DateOnly(1989, 7, 14), true, "Rua do Sol, 888, Natal",
            new OtherInfos("Iniciativa", "Motivado", null, "Corrida")),
        new Person("Natália Araújo", "natalia.araujo@example.com", false, new DateOnly(1981, 6, 3), false, "Rua São João, 1414, Maceió",
            new OtherInfos(null, "Triste", "Quer suporte emocional", "Yoga")),
        new Person("Henrique Lopes", "henrique.lopes@example.com", false, new DateOnly(1979, 12, 1), true, "Rua do Café, 212, São Luís",
            new OtherInfos("Sinceridade", "Calmo", "Ligou recentemente", "Tecnologia")),
        new Person("Letícia Carvalho", "leticia.carvalho@example.com", false, new DateOnly(1998, 10, 2), true, "Av. das Palmeiras, 343, João Pessoa",
            new OtherInfos("Colaboração", "Feliz", null, "Natureza")),
        new Person("Fábio Dias", "fabio.dias@example.com", false, new DateOnly(1986, 9, 11), true, "Rua dos Jacarandás, 515, Aracaju",
            new OtherInfos("Determinação", null, "Contato por chat", "História")),
        new Person("Sabrina Tavares", "sabrina.tavares@example.com", false, new DateOnly(1990, 1, 20), false, "Rua das Oliveiras, 118, Vitória",
            new OtherInfos("Flexibilidade", "Entusiasmada", "Voltou a comprar", "Pintura")),
        new Person("Rodrigo Fonseca", "rodrigo.fonseca@example.com", false, new DateOnly(1980, 4, 4), true, "Rua Paraná, 232, Campo Grande",
            new OtherInfos("Compromisso", "Sereno", null, "Economia")),
        new Person("Isabela Teixeira", "isabela.teixeira@example.com", false, new DateOnly(1991, 2, 23), true, "Av. dos Coqueiros, 400, Macapá",
            new OtherInfos("Zelo", "Animada", "Feedback positivo", "Maquiagem")),
        new Person("Marcelo Farias", "marcelo.farias@example.com", false, new DateOnly(1985, 7, 7), false, "Rua Maranhão, 303, Porto Velho",
            new OtherInfos("Humildade", "Esperançoso", "Voltou recentemente", "Jogos")),
        new Person("Gustavo Silva", "gustavo.silva@example.com", false, new DateOnly(1993, 12, 12), true, "Av. Central, 99, São Paulo",
            new OtherInfos("Ambição", "Empolgado", null, "Negócios")),
        new Person("Amanda Dias", "amanda.dias@example.com", false, new DateOnly(1996, 5, 5), true, "Rua 13 de Maio, 777, Campinas",
            new OtherInfos("Confiança", "Sorridente", null, "Viagens")),
        new Person("Felipe Souza", "felipe.souza@example.com", false, new DateOnly(1987, 3, 19), false, "Rua das Palmeiras, 1010, Osasco",
            new OtherInfos("Foco", "Reservado", "Desativado", "Tecnologia")),
        new Person("Cláudia Rocha", "claudia.rocha@example.com", false, new DateOnly(1982, 6, 30), true, "Rua da Independência, 303, Bauru",
            new OtherInfos("Compreensão", "Gentil", "Atendimento elogiado", "Saúde")),
        new Person("Rafael Mendes", "rafael.mendes@example.com", false, new DateOnly(1994, 8, 28), true, "Av. Brasil, 909, São Vicente",
            new OtherInfos("Sabedoria", "Observador", "Avaliação positiva", "Robótica")),
        new Person("Vanessa Lima", "vanessa.lima@example.com", false, new DateOnly(1988, 11, 16), true, "Rua Sete de Setembro, 606, Jundiaí",
            new OtherInfos("Tolerância", "Pacífica", null, "Cinema")),
        new Person("Douglas Costa", "douglas.costa@example.com", false, new DateOnly(1976, 9, 3), false, "Rua do Comércio, 222, Guarulhos",
            new OtherInfos("Persistência", "Cético", null, "Esportes")),
        new Person("Renata Almeida", "renata.almeida@example.com", false, new DateOnly(1990, 10, 10), true, "Rua Projetada, 808, Barueri",
            new OtherInfos("Iniciativa", "Proativa", "Sugestão de melhorias", "Tecnologia"))
    };

            personsDB.AddRange(staticPersons);
        }
    }
}