# Meeting Organizer

Toplantı planlanma ve yönetim uygulaması

- Entity Framework 6
- SQL Server LocalDB
- Unity DI
- AutoMapper

# API Resources

**GET** Kayıtlı tüm toplantılar
> /api/meetings

**GET** Planlanmış bir toplantıyı görüntüle
> /api/meetings/{id}

**POST** Yeni bir toplantı planla
> /api/meetings/plan

**POST** Toplantıyı güncelle
> /api/meetings/update

**POST** Planlanan toplantıyı sil
> /api/meetings/{id}/delete
