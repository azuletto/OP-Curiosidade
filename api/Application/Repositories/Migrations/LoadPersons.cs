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
                new Person("João Silva", "joao.silva@example.com", false, new DateOnly(1985, 5, 15), true, "Rua das Flores, 123, São Paulo", new DateTime(2023, 3, 12, 8, 30, 0),
                    new OtherInfos("Honestidade", "Feliz", "Cliente desde 2010", "Tecnologia")),
                new Person("Maria Santos", "maria.santos@example.com", false, new DateOnly(1990, 8, 22), true, "Avenida Brasil, 456, Rio de Janeiro", new DateTime(2024, 1, 5, 14, 15, 0),
                    new OtherInfos("Respeito", "Motivada", "Preferência por e-mail", "Música")),
                new Person("Carlos Oliveira", "carlos.oliveira@example.com", false, new DateOnly(1978, 3, 10), false, "Rua São Paulo, 789, Belo Horizonte", new DateTime(2025, 7, 3, 9, 45, 0),
                    new OtherInfos("Responsabilidade", null, "Solicitou newsletter", "Esportes")),
                new Person("Ana Souza", "ana.souza@example.com", false, new DateOnly(1992, 11, 5), true, "Avenida Paulista, 1011, São Paulo", new DateTime(2024, 11, 18, 16, 20, 0),
                    new OtherInfos("Empatia", "Gratidão", null, "Leitura")),
                new Person("Pedro Rodrigues", "pedro.rodrigues@example.com", false, new DateOnly(1988, 7, 30), true, "Rua do Comércio, 1314, Porto Alegre", new DateTime(2025, 2, 28, 11, 10, 0),
                    new OtherInfos("Trabalho em equipe", "Animado", "Indicado por amigo", "Viagens")),
                new Person("Lucia Ferreira", "lucia.ferreira@example.com", false, new DateOnly(1975, 9, 18), false, "Avenida Central, 1516, Curitiba", new DateTime(2025, 7, 15, 13, 25, 0),
                    new OtherInfos(null, "Paz interior", "Cliente VIP", "Cinema")),
                new Person("Bruno Lima", "bruno.lima@example.com", false, new DateOnly(1991, 6, 25), true, "Rua Bahia, 100, Salvador", new DateTime(2023, 8, 7, 10, 5, 0),
                    new OtherInfos("Persistência", "Confiante", "Novo cliente", "Culinária")),
                new Person("Fernanda Costa", "fernanda.costa@example.com", false, new DateOnly(1983, 2, 19), true, "Rua das Laranjeiras, 78, Recife", new DateTime(2024, 4, 22, 15, 30, 0),
                    new OtherInfos("Autenticidade", "Animada", "Cliente recorrente", "Dança")),
                new Person("Ricardo Almeida", "ricardo.almeida@example.com", false, new DateOnly(1970, 12, 12), false, "Avenida Maranhão, 456, Teresina", new DateTime(2025, 6, 8, 12, 0, 0),
                    new OtherInfos("Transparência", null, null, "Política")),
                new Person("Juliana Rocha", "juliana.rocha@example.com", false, new DateOnly(1996, 4, 3), true, "Rua Ceará, 345, Fortaleza", new DateTime(2025, 7, 22, 17, 45, 0),
                    new OtherInfos("Lealdade", "Esperançosa", "Indicação", "Fotografia")),
                new Person("Eduardo Martins", "eduardo.martins@example.com", false, new DateOnly(1984, 9, 8), false, "Avenida Amazonas, 213, Manaus", new DateTime(2023, 12, 14, 9, 15, 0),
                    new OtherInfos("Justiça", "Reflexivo", "Solicitou contato", "Astronomia")),
                new Person("Patrícia Nogueira", "patricia.nogueira@example.com", false, new DateOnly(1993, 10, 29), true, "Rua Belém, 919, Belém", new DateTime(2024, 7, 30, 14, 50, 0),
                    new OtherInfos("Coragem", "Determinada", null, "Teatro")),
                new Person("Tiago Mello", "tiago.mello@example.com", false, new DateOnly(1987, 11, 20), true, "Rua Piauí, 101, Goiânia", new DateTime(2025, 1, 19, 8, 20, 0),
                    new OtherInfos("Comprometimento", "Alegre", "Promoção ativa", "Séries")),
                new Person("Camila Mendes", "camila.mendes@example.com", false, new DateOnly(1995, 1, 15), true, "Avenida Goiás, 606, Brasília", new DateTime(2025, 7, 10, 10, 30, 0),
                    new OtherInfos("Paixão", "Inspirada", "Interesse recente", "Moda")),
                new Person("Anderson Souza", "anderson.souza@example.com", false, new DateOnly(1982, 5, 9), false, "Rua Tocantins, 321, Palmas", new DateTime(2023, 5, 21, 13, 10, 0),
                    new OtherInfos("Visão", null, "Antigo cliente", "Carros")),
                new Person("Aline Ribeiro", "aline.ribeiro@example.com", false, new DateOnly(1997, 8, 18), true, "Rua Acre, 77, Boa Vista", new DateTime(2024, 9, 3, 16, 40, 0),
                    new OtherInfos("Paciência", "Contente", null, "Arquitetura")),
                new Person("Roberta Cunha", "roberta.cunha@example.com", false, new DateOnly(1994, 3, 27), true, "Av. das Américas, 654, Florianópolis", new DateTime(2025, 3, 17, 11, 25, 0),
                    new OtherInfos("Gratidão", "Empolgada", "Fez curso", "Desenho")),
                new Person("Vinícius Braga", "vinicius.braga@example.com", false, new DateOnly(1989, 7, 14), true, "Rua do Sol, 888, Natal", new DateTime(2025, 7, 5, 9, 15, 0),
                    new OtherInfos("Iniciativa", "Motivado", null, "Corrida")),
                new Person("Natália Araújo", "natalia.araujo@example.com", false, new DateOnly(1981, 6, 3), false, "Rua São João, 1414, Maceió", new DateTime(2023, 10, 29, 14, 0, 0),
                    new OtherInfos(null, "Triste", "Quer suporte emocional", "Yoga")),
                new Person("Henrique Lopes", "henrique.lopes@example.com", false, new DateOnly(1979, 12, 1), true, "Rua do Café, 212, São Luís", new DateTime(2024, 2, 14, 10, 50, 0),
                    new OtherInfos("Sinceridade", "Calmo", "Ligou recentemente", "Tecnologia")),
                new Person("Letícia Carvalho", "leticia.carvalho@example.com", false, new DateOnly(1998, 10, 2), true, "Av. das Palmeiras, 343, João Pessoa", new DateTime(2025, 7, 18, 15, 10, 0),
                    new OtherInfos("Colaboração", "Feliz", null, "Natureza")),
                new Person("Fábio Dias", "fabio.dias@example.com", false, new DateOnly(1986, 9, 11), true, "Rua dos Jacarandás, 515, Aracaju", new DateTime(2023, 7, 22, 8, 45, 0),
                    new OtherInfos("Determinação", null, "Contato por chat", "História")),
                new Person("Sabrina Tavares", "sabrina.tavares@example.com", false, new DateOnly(1990, 1, 20), false, "Rua das Oliveiras, 118, Vitória", new DateTime(2025, 4, 5, 12, 35, 0),
                    new OtherInfos("Flexibilidade", "Entusiasmada", "Voltou a comprar", "Pintura")),
                new Person("Rodrigo Fonseca", "rodrigo.fonseca@example.com", false, new DateOnly(1980, 4, 4), true, "Rua Paraná, 232, Campo Grande", new DateTime(2024, 8, 19, 17, 20, 0),
                    new OtherInfos("Compromisso", "Sereno", null, "Economia")),
                new Person("Isabela Teixeira", "isabela.teixeira@example.com", false, new DateOnly(1991, 2, 23), true, "Av. dos Coqueiros, 400, Macapá", new DateTime(2025, 7, 29, 14, 15, 0),
                    new OtherInfos("Zelo", "Animada", "Feedback positivo", "Maquiagem")),
                new Person("Marcelo Farias", "marcelo.farias@example.com", false, new DateOnly(1985, 7, 7), false, "Rua Maranhão, 303, Porto Velho", new DateTime(2023, 9, 11, 11, 5, 0),
                    new OtherInfos("Humildade", "Esperançoso", "Voltou recentemente", "Jogos")),
                new Person("Gustavo Silva", "gustavo.silva@example.com", false, new DateOnly(1993, 12, 12), true, "Av. Central, 99, São Paulo", new DateTime(2024, 12, 24, 9, 30, 0),
                    new OtherInfos("Ambição", "Empolgado", null, "Negócios")),
                new Person("Amanda Dias", "amanda.dias@example.com", false, new DateOnly(1996, 5, 5), true, "Rua 13 de Maio, 777, Campinas", new DateTime(2025, 5, 17, 16, 25, 0),
                    new OtherInfos("Confiança", "Sorridente", null, "Viagens")),
                new Person("Felipe Souza", "felipe.souza@example.com", false, new DateOnly(1987, 3, 19), false, "Rua das Palmeiras, 1010, Osasco", new DateTime(2023, 11, 30, 13, 40, 0),
                    new OtherInfos("Foco", "Reservado", "Desativado", "Tecnologia")),
                new Person("Cláudia Rocha", "claudia.rocha@example.com", false, new DateOnly(1982, 6, 30), true, "Rua da Independência, 303, Bauru", new DateTime(2025, 7, 8, 10, 20, 0),
                    new OtherInfos("Compreensão", "Gentil", "Atendimento elogiado", "Saúde")),
                new Person("Rafael Mendes", "rafael.mendes@example.com", false, new DateOnly(1994, 8, 28), true, "Av. Brasil, 909, São Vicente", new DateTime(2024, 6, 13, 15, 15, 0),
                    new OtherInfos("Sabedoria", "Observador", "Avaliação positiva", "Robótica")),
                new Person("Vanessa Lima", "vanessa.lima@example.com", false, new DateOnly(1988, 11, 16), true, "Rua Sete de Setembro, 606, Jundiaí", new DateTime(2023, 4, 28, 14, 50, 0),
                    new OtherInfos("Tolerância", "Pacífica", null, "Cinema")),
                new Person("Douglas Costa", "douglas.costa@example.com", false, new DateOnly(1976, 9, 3), false, "Rua do Comércio, 222, Guarulhos", new DateTime(2025, 7, 1, 8, 10, 0),
                    new OtherInfos("Persistência", "Cético", null, "Esportes")),
                new Person("Renata Almeida", "renata.almeida@example.com", false, new DateOnly(1990, 10, 10), true, "Rua Projetada, 808, Barueri", new DateTime(2024, 5, 9, 12, 30, 0),
                    new OtherInfos("Iniciativa", "Proativa", "Sugestão de melhorias", "Tecnologia"))
            };

            personsDB.AddRange(staticPersons);
        }
    }
}