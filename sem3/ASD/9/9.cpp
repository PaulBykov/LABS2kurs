#include "D:/help/feat.hpp"

using namespace std;


#define START_FROM 0

#define MUTATION_PRECENTAGE 0.1


namespace Genetic {

	int random(int min, int max) {
		std::random_device rd;
		std::mt19937 gen(rd());
		std::uniform_int_distribution<int> distribution(min, max);

		return distribution(gen);
	}

	void customSort(std::vector<std::vector<int>>& gens, std::vector<int>& weights) {
		// Создаем вспомогательный вектор пар (индекс, значение)
		std::vector<std::pair<int, int>> pairs;
		for (int i = 0; i < weights.size(); ++i) {
			pairs.emplace_back(i, weights[i]);
		}

		// Сортируем пары по значениям weights
		std::sort(pairs.begin(), pairs.end(), [](const auto& a, const auto& b) {
			return a.second < b.second;
			});

		// Создаем временные векторы для хранения отсортированных значений
		std::vector<std::vector<int>> sortedGens(gens.size(), std::vector<int>(gens[0].size()));
		std::vector<int> sortedWeights(weights.size());

		// Переносим значения в соответствии с отсортированным порядком weights
		for (int i = 0; i < weights.size(); ++i) {
			int originalIndex = pairs[i].first;
			sortedWeights[i] = pairs[i].second;
			sortedGens[i] = gens[originalIndex];
		}

		// Обновляем входные массивы
		weights = sortedWeights;
		gens = sortedGens;
	}

	void printPopulation(vector<int> population, int distance) {
		for (auto elem : population) {
			cout << elem << " ";
		}

		cout << "  |  " << distance << "\n";
	}

	long wayLen(vector<int> way, vector<vector<int>> a) {
		long wayLong = 0;
		for (int i = 1; i < way.size(); i++) {
			wayLong += a[way[i - 1]][way[i]];
		}

		return wayLong;
	}

	void mutate(vector<int> &genom, int &distance, vector<vector<int>> &a) {
		int v1 = random(1, genom.size() - 2);
		int v2 = random(1, genom.size() - 2);

		swap(genom[v1], genom[v2]);
		distance = wayLen(genom, a);
	}

	pair<vector<vector<int>>, vector<int>> GeneratePopulation(int size, int ECount, vector<vector<int>>& a) {
		vector< vector<int> > population(size, vector<int>(ECount + 1, 0));
		vector<int> distance(size, 0);

		for (int i = 0; i < ECount; i++) {
			if(i != START_FROM)
				population[0][i] = i;
		}

		//замыкаем
		population[0][0] = START_FROM;
		population[0][ECount] = START_FROM;


		for (int i = 1; i < size; i++) {
			population[i] = population[i - 1];
		iter:
			random_shuffle(++population[i].begin(), population[i].end() - 1);

			long len = Genetic::wayLen(population[i], a);
			if (len > INF) {
				goto iter;
			}
			distance[i] = len;
		}
		
		distance[0] = Genetic::wayLen(population[0], a);


		return make_pair(population, distance);
	}

	vector<int> fuckYourSelf(vector<int> gen1, vector<int> gen2) {
		std::vector<int> newGen;
		std::vector<bool> taken(gen1.size(), false); // Массив для отслеживания взятых элементов

		int length = gen1.size();
		int crossoverPoint = rand() % length;

		newGen.push_back(START_FROM);
		taken[START_FROM] = true;

		for (int i = 1; i < crossoverPoint; ++i) {
			newGen.push_back(gen1[i]);
			taken[gen1[i]] = true;
		}

		for (int i = crossoverPoint; i < length - 1; ++i) {
			if (!taken[gen2[i]]) {
				newGen.push_back(gen2[i]);
				taken[gen2[i]] = true;
			}
		}

		// Добавление недостающих элементов из второго родителя
		for (int i = 1; i < length - 1; ++i) {
			if (!taken[gen2[i]]) {
				newGen.push_back(gen2[i]);
				taken[gen2[i]] = true;
			}
		}

		newGen.push_back(START_FROM);

		/*cout << "||||||||||||||||||||||||||||||||||||||||||||\n";
		printVector(gen1);
		cout << "\t ++++++++++ \t";
		printVector(gen2);
		cout << "\t ========== \t";
		printVector(newGen);

		cout << "||||||||||||||||||||||||||||||||||||||||||||\n";*/

		return newGen;
	}

	void StartGeneticAlgo(vector<vector<int>>& a, int startPopulationSize, int sonsCount, int evolutionsCount) {
		pair<vector<vector<int>>, vector<int>> ans = Genetic::GeneratePopulation(startPopulationSize, a.size(), a);

		vector<vector<int>> populations = ans.first;
		vector<int> lenghts = ans.second;

		printMatrix(populations);
		printVector(lenghts);

		for (int t = 0; t < evolutionsCount; t++) {
			vector<vector<int>> newPopulation;
			vector<int> newLenghts;

			for (int i = 0; i < sonsCount; i++) {
				int daddyIndex = random(0, populations.size() - 1);
				int momyIndex = random(0, populations.size() - 1);

				do {
					momyIndex = random(0, populations.size() - 1); // regenarate while same gen PYTHOIN BLYATA BIM BIM BAM BAM
				} while (momyIndex == daddyIndex);


				newPopulation.push_back(fuckYourSelf(populations[daddyIndex], populations[momyIndex]));
				newLenghts.push_back(wayLen(newPopulation[newPopulation.size() - 1], a));


				bool doMutation = random(0, 1) < (MUTATION_PRECENTAGE);
				if (doMutation)
					mutate(newPopulation[newPopulation.size() - 1], newLenghts[newLenghts.size() - 1], a);
			}
			

			for (int i = 0; i < newPopulation.size(); i++) {
				populations.push_back(newPopulation[i]);
				lenghts.push_back(newLenghts[i]);
			}

			
			customSort(populations, lenghts);

			populations.erase(populations.end() - newPopulation.size(), populations.end()); // !!! newPopulation.size() РАВНО sonsCount
			lenghts.erase(lenghts.end() - newPopulation.size(), lenghts.end());


			cout << "-------------------------------------------\n";
			cout << "\t\t STEP " << t+1 << " \t\t\n";

			cout << "Минимальный маршрут: "; 
			printVector(populations[0]);

			cout << "Его длина: "; 
			cout << (lenghts[0]) << "\n";



			/*for (int q = 0; q < populations.size(); q++) {
				printPopulation(populations[q], lenghts[q]);
			}*/
		}
		
		
	}

}

//vector<vector<int>> a = { {0, 25, 40, 31, 27},
//						  {5, 0, 17, 30, 25},
//						  {19, 15, 0, 6, 1},
//						  {9, 50, 24, 0, 6},
//						  {22, 25, 7, 10, 0},
//};

vector<vector<int>> a = {   {0, 10, 15, 20, 25, 30, 35, 40, 45, 50},
							{10, 0, 12, 18, 22, 28, 33, 38, 43, 48},
							{15, 12, 0, 13, 17, 23, 28, 33, 38, 43},
							{20, 18, 13, 0, 15, 20, 25, 30, 35, 40},
							{25, 22, 17, 15, 0, 10, 15, 20, 25, 30},
							{30, 28, 23, 20, 10, 0, 10, 15, 20, 25},
							{35, 33, 28, 25, 15, 10, 0, 11, 15, 20},
							{40, 38, 33, 30, 20, 15, 11, 0, 10, 15},
							{45, 43, 38, 35, 25, 20, 15, 10, 0, 12},
							{50, 48, 43, 40, 30, 25, 20, 15, 12, 0},
};

int n = a.size();



void replaceZerosToINF(vector<vector<int>> &a) {
	for (int i = 0; i < a.size(); i++) {
		for (int j = 0;j < a[i].size(); j++) {
			if (a[i][j] == 0) {
				a[i][j] = INF;
			}
		}
	}

}


void menu() {
	cout << "1) Добавить вершину \n";
	cout << "2) Добавить ребро \n";
	cout << "3) Начать алгоритм \n";

	int choice;
	cin >> choice;

	switch (choice) {
	case 1:
		{
			for (int i = 0; i < a.size(); ++i) {
				a[i].push_back(0);
			}

			vector<int> newRow(a[0].size(), 0);
			a.push_back(newRow);
			printMatrix(a);
		}

		menu();
		break;
	case 2:
	{
		cout << "Введите номера вершин для ребра и его вес: ";
		int from, to, weight;

		cin >> from >> to >> weight;

		int vertices = a.size();

		if (from >= vertices || to >= vertices || from < 0 || to < 0) {
			cout << "Ошибка: Недопустимые вершины!" << endl;
			return;
		}

		a[from][to] = weight;
	}

		printMatrix(a);

		menu();
		break;
	case 3:
		int startPopulationSize, sonsCount, evolutionsCount;
		cout << "Введите начальный размер популяции: ";
		cin >> startPopulationSize;
		
		cout << "Введите количество потомков при скрещивании: ";
		cin >> sonsCount;
		
		cout << "Введите количество эволюций: ";
		cin >> evolutionsCount;

		replaceZerosToINF(a);

		Genetic::StartGeneticAlgo(a, startPopulationSize, sonsCount, evolutionsCount);

		break;
	}
}


int main() {
	RU;
	includeFastIO();


	menu();

	return 0;
}


